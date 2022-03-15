using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectileController : MonoBehaviour
{

    public GameObject AreaEffectPrefab;

    public ElementType ElementType = ElementType.Fire;
    public float Speed = 5f;
    public float CollisionDamage = 2f;

    public bool isAreaEffect = false;
    public float AreaDamage = 0f; 

    public bool HasPenetrateLlimit = true;
    public int PenetrateTimes = 0;

    [SerializeField] private HitEffectTarget hitEffectTarget = HitEffectTarget.Enemy;

    [SerializeField] private float autoDestructionTime = 10f;



    public float AreaScale = 1f;

    private enum HitEffectTarget
    {
        Projectile = 0,
        Enemy = 1,
    }

    private void Start()
    {
        Invoke(nameof(DestroyGameObj), autoDestructionTime);
    }

    private void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector3.up, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Enemy")) return;

        if (!isAreaEffect)
        {
            SpellDamageDealer.Deal(ElementType, collision.gameObject, CollisionDamage);
            if (hitEffectTarget == HitEffectTarget.Enemy)
            {
                Utils.GetHitEffectGenerator().InitHitEffect(ElementType, collision.gameObject, new Vector3(0.5f, 1f, 0));
            }
            else if (hitEffectTarget == HitEffectTarget.Projectile)
            {
				Utils.GetHitEffectGenerator().InitHitEffect(ElementType, this.gameObject, new Vector3(0.5f, 1f, 0));
            }
            if (HasPenetrateLlimit)
            {
                PenetrateTimes--;
                if (PenetrateTimes < 0)
                {
                    GetComponent<Collider2D>().enabled = false;
                    DestroyGameObj();
                }
            }
        }
        else
        {
            if (HasPenetrateLlimit)
            {
                PenetrateTimes--;
                if (PenetrateTimes < 0)
                {
                    GetComponent<Collider2D>().enabled = false;
                    DestroyGameObj();
                }
            }
            GenerateExplosion(transform, AreaScale, AreaDamage);
        }

    }

    private void GenerateExplosion(Transform target, float scale, float damage)
    {
        GameObject explosion = Instantiate(AreaEffectPrefab, target.position, Quaternion.identity);
        ExplosionController explosionController = explosion.GetComponent<ExplosionController>();
        explosionController.ElementType = ElementType;
        explosionController.Scale = scale;
    }

    private void DestroyGameObj()
    {
        Destroy(gameObject);
    }
}
