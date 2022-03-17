using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorchZoneController : MonoBehaviour
{
    [SerializeField] private ElementType elementType = ElementType.Fire;

    private float damageIntervalTimer = 0f;
    [SerializeField] private float damageIntervalTime = 0.5f;
    [SerializeField] public int Damage = 15;

    [SerializeField] private float expandTime = 0.2f;
    [SerializeField] private float durationTime = 5;
    [SerializeField] private float disapperTime = 0.3f;

    [SerializeField] public float scaleRatio = 1;
    // when the scale == Vector3.one, the radius of the sprite
    [SerializeField] private float defaultRadius = 1.6f;

    [SerializeField] private bool hasForce = false;
    [SerializeField] private float forceFactor = 10f;

    [SerializeField] private bool isRotate = false;
    [SerializeField] private float rotateSpeed = 120f;

    private float expandSpeed;
    private float disapperSpeed;

    private void Start()
    {
        transform.localScale = Vector3.zero;

        expandSpeed = scaleRatio / expandTime;
        disapperSpeed = scaleRatio / disapperTime;
        damageIntervalTimer = damageIntervalTime;
    }

    private void Update()
    {
        UpdateRotate();
        UpdateScale();
    }

    private void UpdateRotate()
    {
        if (isRotate)
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotateSpeed));
        }

    }

    private void UpdateScale()
    {
        if (expandTime > 0)
        {
            transform.localScale += expandSpeed * Time.deltaTime * Vector3.one;
            expandTime -= Time.deltaTime;
        }
        else if (durationTime > 0 && expandTime <= 0)
        {
            if (damageIntervalTimer <= 0f)
            {
                // Reset Timer
                damageIntervalTimer = damageIntervalTime;
                DamageToEnemies();
            }
            damageIntervalTimer -= Time.deltaTime;
            durationTime -= Time.deltaTime;
        }
        else if (durationTime < 0 && disapperTime > 0)
        {
            transform.localScale -= disapperSpeed * Time.deltaTime * Vector3.one;
            disapperTime -= Time.deltaTime;
        }
        else if (disapperTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void DamageToEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, defaultRadius * scaleRatio);
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    SpellDamageDealer.Deal(elementType, collider.gameObject, Damage);
                    Utils.GetHitEffectGenerator().InitHitEffect(elementType, collider.transform.position);

                    if (hasForce)
                    {
                        Vector2 force = (collider.transform.position - transform.position).normalized * forceFactor;
                        collider.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
                    }

                }
            }
        }
    }

}
