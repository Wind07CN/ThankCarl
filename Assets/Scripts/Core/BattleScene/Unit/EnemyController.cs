using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private float enemySpeed = Constants.EnemyDefaultMoveSpeed;
	[SerializeField] private int enemyMaxLife = Constants.EnemyDefaultMaxLife;
	[SerializeField] private int enemyArmour = Constants.EnemyDefaultArmour;

	// When enemy is inited, is not active mmediately
	[SerializeField] private float enemyActiveTime = Constants.EnemyDefaultActiveTime;

	public EnemyAttribute enemy;

	private PlayerAttribute mPlayer;
	private PlayerController mPlayerController;

	public void Start()
	{
		InitEnemy();
	}


	public void Update()
	{
		if (mPlayer.IsActive)
		{
			if (enemy.IsAlive && enemy.IsActive)
			{
				TrackPlayer();
			}
			if (!enemy.IsAlive)
			{
				KillEnemy();
			}
		}
	}

	private void InitEnemy()
	{

		enemy = new EnemyAttribute();

		mPlayerController = GameObject.FindWithTag("MainController").GetComponent<BattleSceneController>().playerController;
		mPlayer = GameObject.FindWithTag("MainController").GetComponent<BattleSceneController>().player;

		// Set Value
		enemy.MaxLife = enemyMaxLife;
		enemy.CurrentLife = enemyMaxLife;
		enemy.Armour = enemyArmour;
		enemy.MoveSpeed = enemySpeed;

		// Active Enemy After Set Time 
		enemy.IsActive = false;
		Invoke("SetEnemyActive", enemyActiveTime);
	}

	private void SetEnemyActive()
	{
		enemy.IsActive = true;

		// 结束待机（无敌）动画
	}


	// *************

	private void TrackPlayer()
	{
		if (mPlayer.IsAlive)
		{
			// calculate
			Vector2 orientation = mPlayerController.transform.position - transform.position;

			float angle = Mathf.Atan2(orientation.y, orientation.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.Translate(Vector2.right * enemy.MoveSpeed * Time.deltaTime);
		}
	}

	public void DamageEnemy(int damage)
	{
		int finalDamage = damage - enemy.Armour;
		if (finalDamage > 0)
		{
			enemy.CurrentLife -= finalDamage;
		}
	}

	public void KillEnemy()
	{
		// Play Death Animation & Create Explosion 

		// Remove this GameObject
		Destroy(gameObject);
	}



}