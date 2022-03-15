using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanAeraAttackController : MonoBehaviour
{
    [SerializeField] private int damage = 100;

    [SerializeField] private float explosionRadius = 7.5f;
    [SerializeField] private float effectAngle = 30f;

    [SerializeField] private float displayTime = 0.3f;
    [SerializeField] private float disapplearTime = 0.3f;

    [SerializeField] private ElementType elementType = ElementType.Earth;

    private HitEffectGenerator hitEffectGenerator;

    private float maxEffectAngle;
    private float minEffectAngle;
    public float currentAngle;

    private float disapplearSpeed;

    private Transform playerGameobj;

    private void Start()
    {
        hitEffectGenerator = Utils.GetMainController().GetComponent<HitEffectGenerator>();
        DamageToEnemy();
        disapplearSpeed = 1 / disapplearTime * transform.localScale.x;
        playerGameobj = Utils.GetPlayerObject().transform;
    }

    void Update()
    {
        if (displayTime > 0)
        {
            displayTime -= Time.deltaTime;
        }
        else if (disapplearTime > 0 && displayTime <= 0)
        {
            transform.localScale -= disapplearSpeed * Time.deltaTime * Vector3.one;
            disapplearTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        transform.position = playerGameobj.position;
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
                    hitEffectGenerator.InitHitEffect(elementType, collider.transform.position);
                }
            }
        }
    }

}
