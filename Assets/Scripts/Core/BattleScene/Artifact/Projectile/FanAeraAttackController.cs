using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanAeraAttackController : MonoBehaviour
{
    [SerializeField] private int damage = 100;

    [SerializeField] private float explosionRadius = 7.5f;
    [SerializeField] private float effectAngle = 30f;

    private float maxEffectAngle;
    private float minEffectAngle;
    public float currentAngle;
    private void Start()
    {
        DamageToEnemy();
    }

    private void DamageToEnemy()
    {
        currentAngle = transform.localRotation.eulerAngles.z;
        maxEffectAngle = currentAngle + effectAngle / 2;
        minEffectAngle = currentAngle - effectAngle / 2;


        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                float angle = Utils.GetTwoPointsEulerAngle(transform.position, collider.transform.position);
                if (maxEffectAngle >= 360f && angle <= 180f)
                {
                    angle += 360f;
                }

                if (angle <= maxEffectAngle && angle >= minEffectAngle)
                {
                    collider.gameObject.GetComponent<EnemyController>().DamageEnemy(damage);
                }
            }
        }
    }

}
