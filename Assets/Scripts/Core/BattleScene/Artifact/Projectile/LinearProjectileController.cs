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

	[SerializeField] private float autoDestructionTime = 20f;

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
			collision.gameObject.GetComponent<EnemyController>().DamageEnemy(damage);
			Utils.GetExplosionManager().InitExplosion(elementType, collision.transform.position);

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
