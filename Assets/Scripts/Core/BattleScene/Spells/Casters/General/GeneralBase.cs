using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralBase : AbstractSpellCaster
{
    public GameObject Prefab;
    public float ProjectileBasicDamage = 8f;
    public float AreaDamagePenalty = 0.2f;
    private GameObject playerGameobj;
    private List<ElementType> elementList;

    private void Start()
    {
        playerGameobj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {
        elementList = spell.GetElementsCombination();
        int repeat = DetermineRepeatTimes();
        StartCoroutine(LaunchProjectileCoroutine(spell, repeat));
    }

    private IEnumerator LaunchProjectileCoroutine(ISpell spell, int repeat, float delay = 0.1f)
    {
        for (int i = 0; i < repeat; i++)
        {
            GameObject projectile = InstantiatePrefab();
            ConfigureProjectile(
                spell, projectile,
                DetermineSingleProjectileDamage(),
                DetermineExplosionAreaScale(),
                DeterminePenetrateTimes()
            );
            yield return new WaitForSeconds(delay);
        }
    }

    private GameObject InstantiatePrefab()
    {
        GameObject projectile = Instantiate(Prefab, playerGameobj.transform.position, Quaternion.identity);
        projectile.transform.eulerAngles = new Vector3(
            0,
            0,
            playerGameobj.gameObject.GetComponent<PlayerMoveController>().GetMouseAngle()
        );
        return projectile;
    }

    private void ConfigureProjectile(ISpell spell, GameObject projectile, float damage, float areaScale, int penetrate)
    {
        LinearProjectileController projectileController = projectile.GetComponent<LinearProjectileController>();
        if (areaScale > 0)
        {
            // area
            projectileController.isAreaEffect = true;
            projectileController.AreaScale = areaScale;
            projectileController.AreaDamage = damage * AreaDamagePenalty;
        }
        else
        {
            // single projectile
            projectileController.CollisionDamage = damage;
        }
        projectileController.PenetrateTimes = penetrate;
        projectileController.ElementType = spell.GetPrincipalElementType();
        projectileController.HasPenetrateLlimit = true;
    }

    private float DetermineSingleProjectileDamage()
    {
        int fireNumber = CountElement(ElementType.Fire);
        return ProjectileBasicDamage + fireNumber * 15;
    }

    private float DetermineExplosionAreaScale()
    {
        int waterNumber = CountElement(ElementType.Water);
        if (waterNumber == 0) return 0;
        return (float)(waterNumber * 0.5 + 1);
    }

    private int DetermineRepeatTimes()
    {
        int windNumber = CountElement(ElementType.Wind);
        return windNumber + 1;
    }

    private int DeterminePenetrateTimes()
    {
        int earthNumber = CountElement(ElementType.Earth);
        return earthNumber;
    }

    private int CountElement(ElementType target)
    {
        int count = 0;
    
        // first element only affect principle element type
        for (int i = 1; i < elementList.Count; i++)
        {
            if (elementList[i] == target)
            count++;
        }
        return count;
    }

}