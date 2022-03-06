using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
	public int damage = 5;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy") 
		{
			collision.gameObject.GetComponent<EnemyController>().DamageEnemy(damage);
			this.transform.parent.GetComponent<SpriteMoveController>().DestroySub();
			Destroy(gameObject);
		}
	}
}
