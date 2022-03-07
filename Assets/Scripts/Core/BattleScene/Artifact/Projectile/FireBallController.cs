using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private int damage = 2;

	private Animator animator;

	private void Update()
	{
		transform.Translate(Vector3.up * Time.deltaTime * speed, Space.Self);
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy")
		{
			collision.gameObject.GetComponent<EnemyController>().DamageEnemy(damage);
			animator.SetBool("hit", true);
			GetComponent<CapsuleCollider2D>().enabled = false;
		}
	}

	private void DestroyGameObj() 
	{
		Destroy(gameObject);
	}
}
