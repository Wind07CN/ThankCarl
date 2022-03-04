using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	[HideInInspector] public PlayerAttribute playerAttribute = new PlayerAttribute();

	[SerializeField] private int playerMaxLife = Constants.PlayerDefaultMaxLife;
	[SerializeField] private int playerArmour = Constants.PlayerDefaultArmour;
	[SerializeField] private float playerMoveSpeed = Constants.PlayerDefaultMoveSpeed;

	[SerializeField] private int playerDyingHealthLine = 3;

	private bool isInvincible = false;
	[SerializeField] private float invincibleTime = 2f;

	private BattleSceneMainUIController UIController;

	private new PlayerAnimeController animation;

	private void Start()
	{
		InitPlayer();

	}

	private void Update()
	{
		if (!playerAttribute.IsAlive && playerAttribute.IsActive)
		{
			KillPlayer();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!isInvincible)
		{
			if (collision.gameObject.CompareTag("Enemy"))
			{
				EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
				if (enemyController.enemyAttribute.IsActive)
				{
					DamagePlayer(1);

					// Enemy Play dying animation
					enemyController.KillEnemy();
				}
			}
		}
	}

	public void InitPlayer()
	{
		playerAttribute.MaxLife = playerMaxLife;
		playerAttribute.CurrentLife = playerMaxLife;
		playerAttribute.Armour = playerArmour;
		playerAttribute.MoveSpeed = playerMoveSpeed;

		animation = GameObject.FindGameObjectWithTag("PlayerAnimation").GetComponent<PlayerAnimeController>();
		UIController = GameObject.FindGameObjectWithTag("MainUI").GetComponent<BattleSceneMainUIController>();

		// Set Active
		playerAttribute.IsActive = true;
	}

	public void DamagePlayer(int damage)
	{
		playerAttribute.CurrentLife -= damage;
		
		animation.PlayerGetDamage();
		UIController.UpdateLifeBar();

		isInvincible = true;
		Invoke(nameof(ResetIincible), invincibleTime);


		if (playerAttribute.CurrentLife <= playerDyingHealthLine) 
		{
			UIController.PlayerIsDying();
		}
		UIController.GetDamage();
	}

	public void KillPlayer()
	{
		Debug.Log("Player Dead!");
		playerAttribute.IsActive = false;

		animation.PlayerIsDead();
	}

	private void ResetIincible()
	{
		isInvincible = false;
	}


	private void ResetVisable()
	{

	}
}
