using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlController : MonoBehaviour
{
	[SerializeField] private float rotateSpeed = 120f;
	[SerializeField] private float expandSpeed = 2f;
	[SerializeField] private float lastTime = 2f;
	[SerializeField] private float forceFactor = 30f;
	private void Start()
	{
		Invoke(nameof(DestroyObject), lastTime);
	}

	private void Update()
	{
		transform.localScale = transform.localScale + Time.deltaTime * new Vector3(1, 1, 0) * expandSpeed;
		transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotateSpeed));
	}

	private void DestroyObject() 
	{
		Destroy(gameObject);
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag == "Enemy")
		{
			GameObject enemy = collision.gameObject;
			Vector2 force = (enemy.transform.position - transform.position).normalized * forceFactor;
			enemy.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
		}
	}

}
