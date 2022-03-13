using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{

	// ****************should change some to private
	[SerializeField] public float Scale = 1f;
	[SerializeField] public float ExpandTime = 0.2f;
	[SerializeField] public float ResidenceTime = 0.5f;
	[SerializeField] public float DisappearTime = 0.2f;
	[SerializeField] public ElementType ElementType = ElementType.Fire;

	// Thrust is positive, suction is negative
	[SerializeField] public bool HasForce = false;
	[SerializeField] public float ForceFactor = 30f;

	[SerializeField] public float Damage = 10;

	private float expandSpeed;
	private float disappearSpeed;

	private void Awake()
	{
		transform.localScale = Vector3.zero;

		expandSpeed = Scale / ExpandTime;
		disappearSpeed = Scale / DisappearTime;

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
		Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 2f * Scale);
		foreach (Collider2D collider in colliders)
		{
			if (collider.CompareTag("Enemy"))
			{
				GameObject enemy = collider.gameObject;
				SpellDamageDealer.Deal(ElementType, enemy, Damage);

				// hit animation
				Utils.GetExplosionManager().InitCollisionEffect(ElementType, enemy, new Vector3(0.5f, 1f, 0));
				
				// if should give force to enemy, set haveForce true
				if (HasForce)
				{
					Vector2 force = (collider.transform.position - transform.position).normalized * ForceFactor;
					enemy.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
				}
			}
		}
	}

	private void UpdateScale()
	{
		if (ExpandTime > 0)
		{
			transform.localScale += expandSpeed * Time.deltaTime * Vector3.one;
			ExpandTime -= Time.deltaTime;
		}
		else if (ExpandTime <= 0 && ResidenceTime > 0)
		{
			ResidenceTime -= Time.deltaTime;
		}
		else if (DisappearTime > 0 && ResidenceTime <= 0)
		{
			transform.localScale -= disappearSpeed * Time.deltaTime * Vector3.one;
			DisappearTime -= Time.deltaTime;
		}
		else if (DisappearTime <= 0)
		{
			Destroy(gameObject);
		}
	}


}
