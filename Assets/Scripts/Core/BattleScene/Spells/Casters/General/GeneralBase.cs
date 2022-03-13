using UnityEngine;
using System.Collections.Generic;

public abstract class GeneralBase : AbstractSpellCaster
{
    
    public GameObject Prefab;
    public float ProjectileBasicDamage = 8f;
    public float AreaDamagePenalty = 0.2f;

    public override void Cast(ISpell spell)
    {
        List<ElementType> elementList = spell.GetElementsCombination();
        LinearProjectileController projectileController = Prefab.GetComponent<LinearProjectileController>();
        
    }

    private float DetermineSingleProjectileDamage(List<ElementType> elementList)
    {
        int fireNumber = CountElement(ElementType.Fire, elementList);
        return ProjectileBasicDamage + fireNumber * 15;
    }

    private float DetermineExplosionRadius(List<ElementType> elementList)
    {
        int waterNumber = CountElement(ElementType.Water, elementList);
        return (float) (waterNumber * 0.5 + 1);
    }

    private int DetermineRepeatTimes(List<ElementType> elementList)
    {
        int windNumber = CountElement(ElementType.Wind, elementList);
        return windNumber + 1;
    }

    private int DeterminePenetrateTimes(List<ElementType> elementList)
    {
        int earthNumber = CountElement(ElementType.Earth, elementList);
        return earthNumber + 1;
    }

    private int CountElement(ElementType target, List<ElementType> list)
    {
        int count = 0;
        foreach (ElementType element in list)
        {
            if (element == target)
                count++;
        }
        return count;
    }

}