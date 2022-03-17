using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropController : MonoBehaviour
{

    [SerializeField] private ElementType elementType = ElementType.Water;

    [SerializeField] private int damage = 5;

    private HitEffectGenerator hitEffectGenerator;

    private void Start()
    {
        hitEffectGenerator = Utils.GetMainController().GetComponent<HitEffectGenerator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().DamageEnemy(damage);
            this.transform.parent.GetComponent<WaterDropMoveController>().DestroySub();
            hitEffectGenerator.InitHitEffect(elementType, collision.transform.position);
            Destroy(gameObject);
        }
    }
}
