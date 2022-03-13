using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectileController : MonoBehaviour
{

    public GameObject AreaEffectPrefab;

    [SerializeField] public ElementType ElementType = ElementType.Fire;
    [SerializeField] public float Speed = 5f;
    [SerializeField] public int CollisionDamage = 2;
    [SerializeField] public bool HasPenetrateLlimit = false;
    [SerializeField] public int PenetrateTime = 0;

    [SerializeField] private HitEffectTarget hitEffectTarget = HitEffectTarget.Enemy;

    [SerializeField] private float autoDestructionTime = 10f;

    public bool isAreaEffect = false;

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
                Utils.GetHitEffectGenerator().InitHitEffect(ElementType, collision.transform.position);
            }
            else if (hitEffectTarget == HitEffectTarget.Projectile)
            {
                Utils.GetHitEffectGenerator().InitHitEffect(ElementType, transform.position);
            }
            if (HasPenetrateLlimit)
            {
                PenetrateTime--;
                if (PenetrateTime < 0)
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
                PenetrateTime--;
                if (PenetrateTime <= 0)
                {
                    GetComponent<Collider2D>().enabled = false;
                    DestroyGameObj();
                }
            }
            GenerateExplosion(transform, AreaScale);
        }

    }

    private void GenerateExplosion(Transform target, float scale)
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
