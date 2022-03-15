using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStoneController : MonoBehaviour
{
    [SerializeField] private ElementType elementType = ElementType.Earth;
    [SerializeField] private int damage = 100;

    [SerializeField] private float enemyStunTime = 1f;
    [SerializeField] private float durationTime = 5f;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float scaleSpeed = 1;
    [SerializeField] private float rotateSpeed = 60f;

    [SerializeField] private float disappearTime = 0.3f;
    private Vector3 direction;
    private float disappearSpeed;

    void Start()
    {
        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;
        direction = (mPos - transform.position).normalized;
        transform.localScale = Vector3.one;
        disappearSpeed = (durationTime * scaleSpeed + 1f) / disappearTime;
    }


    void Update()
    {
        float passTime = Time.deltaTime;
        if (durationTime > 0)
        {
            transform.Translate(moveSpeed * passTime * direction, Space.World);
            transform.localEulerAngles += new Vector3(0, 0, rotateSpeed * passTime);
            transform.localScale += scaleSpeed * passTime * Vector3.one;
            durationTime -= passTime;
        }
        else if (durationTime <= 0 && disappearTime > 0)
        {
            GetComponent<Collider2D>().enabled = false;
            transform.localScale -= disappearSpeed * passTime * Vector3.one;
            disappearTime -= passTime;
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemyController = collision.GetComponent<EnemyController>();
            Utils.GetHitEffectGenerator().InitHitEffect(elementType, collision.transform.position);
            enemyController.DamageEnemy(damage);
            if (enemyController.enemyAttribute.IsAlive)
            {
                enemyController.StunEnemy(enemyStunTime);
            }
        }
    }


}
