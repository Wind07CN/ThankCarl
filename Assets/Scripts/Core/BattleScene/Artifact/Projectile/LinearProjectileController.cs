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

	[SerializeField] private ExplosionPos explosionPosition = ExplosionPos.Enemy;

	[SerializeField] private float autoDestructionTime = 10f;

	public bool isAreaEffect = false;  

	private enum ExplosionPos 
	{
		Projectile = 0,
		Enemy = 1,
		Player = 2,
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
			if (!isAreaEffect)
			{
				SpellDamageDealer.Deal(elementType, collision.gameObject, damage);
				if (explosionPosition == ExplosionPos.Enemy)
				{
					Utils.GetExplosionManager().InitCollisionEffect(elementType, collision.transform.position);
				}
				else if (explosionPosition == ExplosionPos.Projectile)
				{
					Utils.GetExplosionManager().InitCollisionEffect(elementType, transform.position);
				}
				else if (explosionPosition == ExplosionPos.Player) 
				{
					Utils.GetExplosionManager().InitCollisionEffect(elementType, Utils.GetPlayerObject().transform.position);
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
			else 
			{
				// Init explosion here
			}

		}
	}

	private void DestroyGameObj()
	{
		Destroy(gameObject);
	}
}
