using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private float enemySpeed = Constants.EnemyDefaultMoveSpeed;
	[SerializeField] private int enemyMaxLife = Constants.EnemyDefaultMaxLife;
	[SerializeField] private int enemyArmour = Constants.EnemyDefaultArmour;

	// When enemy is inited, is not active mmediately
	[SerializeField] private float enemyActiveTime = Constants.EnemyDefaultActiveTime;

	public EnemyAttribute enemyAttribute;

	private PlayerAttribute playerAttribute;
	private PlayerController playerController;

	public void Start()
	{
		InitEnemy();
	}


	public void Update()
	{
		if (playerAttribute.IsActive)
		{
			if (enemyAttribute.IsAlive && enemyAttribute.IsActive)
			{
				TrackPlayer();
			}
			if (!enemyAttribute.IsAlive)
			{
				KillEnemy();
			}
		}
	}

	private void InitEnemy()
	{

		enemyAttribute = new EnemyAttribute();

		playerController = GameObject.FindWithTag("MainController").GetComponent<BattleSceneController>().playerController;
		playerAttribute = GameObject.FindWithTag("MainController").GetComponent<BattleSceneController>().playerAttribute;

		// Set Value
		enemyAttribute.MaxLife = enemyMaxLife;
		enemyAttribute.CurrentLife = enemyMaxLife;
		enemyAttribute.Armour = enemyArmour;
		enemyAttribute.MoveSpeed = enemySpeed;

		// Active Enemy After Set Time 
		enemyAttribute.IsActive = false;
		Invoke("SetEnemyActive", enemyActiveTime);
	}

	private void SetEnemyActive()
	{
		enemyAttribute.IsActive = true;

		// 结束待机（无敌）动画
	}


	// *************

	private void TrackPlayer()
	{
		if (playerAttribute.IsAlive)
		{
			// calculate
			Vector2 orientation = playerController.transform.position - transform.position;

			float angle = Mathf.Atan2(orientation.y, orientation.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.Translate(Vector2.right * enemyAttribute.MoveSpeed * Time.deltaTime);
		}
	}

	public void DamageEnemy(int damage)
	{
		int finalDamage = damage - enemyAttribute.Armour;
		if (finalDamage > 0)
		{
			enemyAttribute.CurrentLife -= finalDamage;
		}
	}

	public void KillEnemy()
	{
		// Play Death Animation & Create Explosion 

		// Remove this GameObject
		Destroy(gameObject);
	}



}