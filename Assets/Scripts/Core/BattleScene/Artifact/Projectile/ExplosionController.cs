using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{

	// ****************should change some to private
	[SerializeField] public float finalScale = 1f;
	[SerializeField] public float expandTime = 0.5f;
	[SerializeField] public float residenceTime = 0.5f;
	[SerializeField] public float disappearTime = 0.2f;
	[SerializeField] public ElementType elementType = ElementType.Fire;

	// Thrust is positive, suction is negative
	[SerializeField] public bool haveForce = false;
	[SerializeField] public float forceFactor = 30f;

	[SerializeField] public int damage = 10;

	private float expandSpeed;
	private float disappearSpeed;

	private void Awake()
	{
		transform.localScale = Vector3.zero;

		expandSpeed = finalScale / expandTime;
		disappearSpeed = finalScale / disappearTime;

	}
	private void Start()
	{
		ExplosionEffect();
	}

	private void Update()
	{
		UpdateScale();
	}

	private void ExplosionEffect()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 2f * finalScale);
		foreach (Collider2D collider in colliders)
		{
			if (collider.CompareTag("Enemy"))
			{
				GameObject emeny = collider.gameObject;
				emeny.GetComponent<EnemyController>().DamageEnemy(damage);
				
				// if should give force to enemy, set haveForce true
				if (haveForce)
				{
					Vector2 force = (collider.transform.position - transform.position).normalized * forceFactor;
					emeny.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
				}
			}
		}
	}

	private void UpdateScale()
	{
		if (expandTime > 0)
		{
			transform.localScale += expandSpeed * Time.deltaTime * Vector3.one;
			expandTime -= Time.deltaTime;
		}
		else if (expandTime <= 0 && residenceTime > 0)
		{
			residenceTime -= Time.deltaTime;
		}
		else if (disappearTime > 0 && residenceTime <= 0)
		{
			transform.localScale -= disappearSpeed * Time.deltaTime * Vector3.one;
			disappearTime -= Time.deltaTime;
		}
		else if (disappearTime <= 0)
		{
			Destroy(gameObject);
		}
	}


}
