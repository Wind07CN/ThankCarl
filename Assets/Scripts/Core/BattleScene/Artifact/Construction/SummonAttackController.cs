using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAttackController : MonoBehaviour
{
	[SerializeField] private float durationTime;
	[SerializeField] private ElementType elementType = ElementType.Earth;
	[SerializeField] private int bulletDamage = 15;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private float firingIntervalTime = 0.5f;
	[SerializeField] private float fireTimer = 0;
	[SerializeField] private Transform turret;

	private void Update()
	{
		Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mPos.z = 0;
		Vector3 direction = new Vector3(0, 0, Utils.GetTwoPointsEulerAngle(transform.position, mPos));
		turret.eulerAngles = direction;

		if (durationTime <= 0)
		{
			Utils.GetHitEffectGenerator().InitHitEffect(elementType, this.transform.position);
			Destroy(gameObject);
		}
		if (fireTimer <= 0)
		{
			Shot(direction);
			fireTimer = firingIntervalTime;
		}
		fireTimer -= Time.deltaTime;
		durationTime -= Time.deltaTime;

	}

	private void Shot( Vector3 direction)
	{
		GameObject bullet = Instantiate(bulletPrefab, transform.position,
			Quaternion.identity);
		bullet.GetComponent<LinearProjectileController>().CollisionDamage = bulletDamage;
		bullet.transform.eulerAngles = direction;
	}

}
