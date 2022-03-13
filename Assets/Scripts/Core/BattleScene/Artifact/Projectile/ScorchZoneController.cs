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

	[SerializeField] public float ScaleRatio = 1;
	// when the scale == Vector3.one, the radius of the sprite
	[SerializeField] private float defaultRadius = 1.6f;

	private float expandSpeed;
	private float disapperSpeed;

	private void Start()
	{
		transform.localScale = Vector3.zero;

		expandSpeed = ScaleRatio / expandTime;
		disapperSpeed = ScaleRatio / disapperTime;
		damageIntervalTimer = damageIntervalTime;
	}

	private void Update()
	{
		UpdateScale();
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
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, defaultRadius * ScaleRatio);
		{
			foreach (Collider2D collider in colliders)
			{
				if (collider.CompareTag("Enemy"))
				{
					SpellDamageDealer.Deal(elementType, collider.gameObject, Damage);
				}
			}
		}
	}




}
