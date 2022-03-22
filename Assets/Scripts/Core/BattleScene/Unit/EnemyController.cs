using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private ElementType enemyElementType;
	[SerializeField] private int EnemyPoint = 100;
	[SerializeField] private float enemySpeed = Constants.EnemyDefaultMoveSpeed;
	[SerializeField] private int enemyMaxLife = Constants.EnemyDefaultMaxLife;
	[SerializeField] private int enemyArmour = Constants.EnemyDefaultArmour;

	[SerializeField] private float difficultyMultiplier = 1f;

	// When enemy is inited, is not active mmediately
	[SerializeField] private float enemyActiveTime = Constants.EnemyDefaultActiveTime;

	public int damageToPlayer = 1;

	public EnemyAttribute enemyAttribute;

	private PlayerAttribute playerAttribute;
	private GameObject mPlayer;
	private Rigidbody2D mRigidbody;

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
			if (!enemyAttribute.IsAlive && enemyAttribute.IsActive)
			{
				KillEnemy();
			}
		}
	}

	private void InitEnemy()
	{

		enemyAttribute = new EnemyAttribute(enemyElementType);

		mRigidbody = GetComponent<Rigidbody2D>();

		mPlayer = Utils.GetPlayerObject();
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
		GetComponent<EnemyAnimeController>().EnemyActive();
	}



	private void TrackPlayer()
	{
		if (playerAttribute.IsAlive && enemyAttribute.IsActive)
		{
			// calculate
			Vector2 orientation = (mPlayer.transform.position - mRigidbody.transform.position).normalized;

			// 需要重写降低损耗
			if (orientation.x > 0)
			{
				mRigidbody.transform.localScale = new Vector3(-1, 1, 1);
			}
			else
			{
				mRigidbody.transform.localScale = new Vector3(1, 1, 1);
			}

			// enemy rotation 
			// float angle = Mathf.Atan2(orientation.y, orientation.x) * Mathf.Rad2Deg;
			// transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			mRigidbody.transform.Translate(enemyAttribute.MoveSpeed * Time.deltaTime * orientation);
		}
		else if (!playerAttribute.IsAlive && enemyAttribute.IsActive) 
		{
			KillEnemy();
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


	/// <summary>
	/// Cause short stun to the enemy
	/// </summary>
	/// <param name="time"></param>
	public void StunEnemy(float time)
	{
		enemyAttribute.IsActive = false;
		Invoke(nameof(SetEnemyActive), time);
	}

	public ElementType GetEnemyElementType() 
	{
		return enemyElementType;
	}

	/// <summary>
	/// Ignore the life value, directly kill the enemy,
	/// At the same time, players gain points
	/// </summary>
	public void KillEnemy()
	{
		KillEnemyWithoutPoint();
		Utils.GetPlayerObject().GetComponent<PlayerController>().GainPoints(EnemyPoint);
	}


	/// <summary>
	/// Ignore the life value, directly kill the enemy,
	/// Players do not get points
	/// </summary>
	public void KillEnemyWithoutPoint()
	{
		enemyAttribute.IsActive = false;
		mRigidbody.simulated = false;
		GetComponent<EnemyAnimeController>().EnemyDead();
	}

	public SpriteRenderer GetSpriteRenderer()
	{
		return transform.GetComponentInChildren<SpriteRenderer>();
	}



}