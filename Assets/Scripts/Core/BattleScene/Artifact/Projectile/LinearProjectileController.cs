using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearProjectileController : MonoBehaviour
{
	[SerializeField] public ElementType ElementType = ElementType.Fire;
	[SerializeField] public float Speed = 5f;
	[SerializeField] public int Damage = 2;
	[SerializeField] public bool HasNoPenetrateLlimit = false;
	[SerializeField] public int PenetrateTime = 0;

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
		transform.Translate(Speed * Time.deltaTime * Vector3.up, Space.Self);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.CompareTag("Enemy"))
		{
			if (!isAreaEffect)
			{
				SpellDamageDealer.Deal(ElementType, collision.gameObject, Damage);
				if (explosionPosition == ExplosionPos.Enemy)
				{
					Utils.GetExplosionManager().InitCollisionEffect(ElementType, collision.transform.position);
				}
				else if (explosionPosition == ExplosionPos.Projectile)
				{
					Utils.GetExplosionManager().InitCollisionEffect(ElementType, transform.position);
				}
				else if (explosionPosition == ExplosionPos.Player) 
				{
					Utils.GetExplosionManager().InitCollisionEffect(ElementType, Utils.GetPlayerObject().transform.position);
				}
				if (!HasNoPenetrateLlimit)
				{
					PenetrateTime--;
					if (PenetrateTime < 0)
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
