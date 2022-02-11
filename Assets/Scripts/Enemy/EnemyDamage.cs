using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			Debug.Log("Boom!!!!!!");
			collision.gameObject.GetComponent<PlayerController>().player.GetDamage(1f);
			Destroy(this.transform.parent.gameObject);
		}
	}
}
