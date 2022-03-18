using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
	public ElementType ElementType = ElementType.Fire;

	public float Scale = 1f;
	public float ExpandTime = 0.2f;
	public float ResidenceTime = 0.5f;
	public float DisappearTime = 0.2f;

	// when the scale == Vector3.one, the radius of the sprite
	[SerializeField] private float defaultRadius = 1.6f;

	// Thrust is positive, suction is negative
	public bool HasForce = false;
	public float ForceFactor = 30f;

	public float Damage = 10;

	private float expandSpeed;
	private float disappearSpeed;

	private void Start()
	{
		transform.localScale = Vector3.zero;

		expandSpeed = Scale / ExpandTime;
		disappearSpeed = Scale / DisappearTime;
		ExplosionEffect();
	}

	private void Update()
	{
		UpdateScale();
	}

	private void ExplosionEffect()
	{
		if (!HasForce && Damage == 0) return;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, defaultRadius * Scale);
		foreach (Collider2D collider in colliders)
		{
			if (collider.CompareTag("Enemy"))
			{
				GameObject enemy = collider.gameObject;
				SpellDamageDealer.Deal(ElementType, enemy, Damage);

				// hit animation
				Utils.GetHitEffectGenerator().InitHitEffect(ElementType, enemy, new Vector3(0.5f, 1f, 0));

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
