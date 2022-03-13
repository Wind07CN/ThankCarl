using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorchZoneController : MonoBehaviour
{
	[SerializeField] private ElementType elementType = ElementType.Fire;
	private float damageIntervalTimer = 0f;
	[SerializeField] public float damageIntervalTime = 1f;
	[SerializeField] public int damage = 15;

	[SerializeField] public float durationTime = 5;
	[SerializeField] private float disapperTime = 0.3f;

	[SerializeField] public float scaleRatio = 1;
	// when the scale == Vector3.one, the radius of the sprite
	[SerializeField] private float defaultRadius = 1.6f;
	private float disapperSpeed;

	private void Awake()
	{
		transform.transform.localScale = Vector3.one * scaleRatio;
		disapperSpeed = scaleRatio / disapperTime;
	}

	private void Update()
	{
		if (durationTime > 0)
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
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, defaultRadius * scaleRatio);
		{
			foreach (Collider2D collider in colliders)
			{
				if (collider.CompareTag("Enemy"))
				{
					SpellDamageDealer.Deal(elementType, collider.gameObject, damage);
				}
			}
		}
	}




}
