using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectileController : MonoBehaviour
{
	[SerializeField] public ElementType elementType = ElementType.Fire;
	[SerializeField] public float speed = 5f;
	[SerializeField] public int damage = 2;
	[SerializeField] public bool isNoPenetrateLlimit = false;
	[SerializeField] public int penetrateTime = 0;

	[SerializeField] private explosionPos explosionPosition = explosionPos.Enemy;

	[SerializeField] private float autoDestructionTime = 10f;


	private enum explosionPos 
	{
		Projectile = 0,
		Enemy = 1,
	}
	private void Start()
	{
		Invoke(nameof(DestroyGameObj), autoDestructionTime);
	}

	private void Update()
	{
		transform.Translate(speed * Time.deltaTime * Vector3.up, Space.Self);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			SpellDamageDealer.Deal(elementType, collision.gameObject, damage);
			if (explosionPosition == explosionPos.Enemy)
			{
				Utils.GetExplosionManager().InitExplosion(elementType, collision.transform.position);
			}
			else
			{
				Utils.GetExplosionManager().InitExplosion(elementType, transform.position);
			}
			if (!isNoPenetrateLlimit)
			{
				penetrateTime--;
				if (penetrateTime < 0)
				{
					GetComponent<Collider2D>().enabled = false;
					DestroyGameObj();
				}
			}

		}
	}

	private void DestroyGameObj()
	{
		Destroy(gameObject);
	}
}
