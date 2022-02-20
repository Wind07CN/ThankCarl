using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private float enemySpeed = Constants.EnemyDefaultMoveSpeed;
	[SerializeField] private int enemyMaxLife = Constants.EnemyDefaultMaxLife;
	[SerializeField] private int enemyArmour = Constants.EnemyDefaultArmour;

	[SerializeField] private float difficultyMultiplier = 1f;

	// When enemy is inited, is not active mmediately
	[SerializeField] private float enemyActiveTime = Constants.EnemyDefaultActiveTime;

	public EnemyAttribute enemyAttribute;

	private PlayerAttribute playerAttribute;
	private GameObject mPlayer;

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

		mPlayer = GameObject.FindWithTag("Player");
		playerAttribute = Utils.GetPlayerAttribute();
		difficultyMultiplier = Utils.GetMainController().difficultyMultiplier;

		// Set Value
		enemyAttribute.MaxLife = (int)(enemyMaxLife * difficultyMultiplier);
		enemyAttribute.CurrentLife = enemyAttribute.MaxLife;
		enemyAttribute.Armour = enemyArmour;
		enemyAttribute.MoveSpeed = enemySpeed;

		// Active Enemy After Set Time 
		enemyAttribute.IsActive = false;
		Invoke(nameof(SetEnemyActive), enemyActiveTime);
	}

	public void SetDifficultyMultiplier(float multiplier)
	{
		difficultyMultiplier = multiplier;
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
			Vector2 orientation = mPlayer.transform.position - transform.position;

			float angle = Mathf.Atan2(orientation.y, orientation.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.Translate(enemyAttribute.MoveSpeed * Time.deltaTime * Vector2.right);
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

	public void StunEnemy(float time)
	{
		enemyAttribute.IsActive = false;
		Invoke(nameof(SetEnemyActive), time);
	}



	public void KillEnemy()
	{
		// Play Death Animation & Create Explosion 

		// Remove this GameObject
		Destroy(gameObject);
	}



}