using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	[HideInInspector] public PlayerAttribute playerAttribute = new PlayerAttribute();

	[SerializeField] private int playerMaxLife = Constants.PlayerDefaultMaxLife;
	[SerializeField] private int playerArmour = Constants.PlayerDefaultArmour;
	[SerializeField] private float playerMoveSpeed = Constants.PlayerDefaultMoveSpeed;
	[SerializeField] private float playerManaRegenSpeed = Constants.PlayerDefaultManaRegenSpeed;

	[SerializeField] private int playerDyingLifeThreshold = 3;

	
	[SerializeField] private float invincibleTime = 2f;
	[SerializeField] private GameObject invincibleAnime;
	private bool isInvincible = false;

	[SerializeField] private CollisionEffectManager explosionManager;

	private BattleSceneMainUIController UIController;

	private new PlayerAnimeController animation;

	private void Start()
	{
		InitPlayer();
	}

	private void Update()
	{
		RegenerateMana();
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
					DamagePlayer(enemyController.damageToPlayer);

					// Enemy Play dying animation
					enemyController.KillEnemy();

					// 这里需要一个新的控制器专门控制产生爆炸效果
					explosionManager.InitCollisionEffect(enemyController.GetEnemyElementType(), transform.position);
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
		playerAttribute.ManaRegenSpeed = playerManaRegenSpeed;

		animation = GameObject.FindGameObjectWithTag("PlayerAnimation").GetComponent<PlayerAnimeController>();
		UIController = GameObject.FindGameObjectWithTag("MainUI").GetComponent<BattleSceneMainUIController>();

		// Set Active
		// 这里需要倒计时
		// 需要使用协程
		playerAttribute.IsActive = true;
	}

	public void DamagePlayer(int damage)
	{
		playerAttribute.CurrentLife -= damage;

		// UI update
		UIController.UpdateLifeBar();

		// UI shark
		UIController.GetDamage();

		if (playerAttribute.IsAlive)
		{
			// Anime
			animation.PlayerGetDamage();

			// Invincible
			isInvincible = true;
			invincibleAnime.SetActive(true);
			Invoke(nameof(ResetIincible), invincibleTime);

			// Is player dying
			if (playerAttribute.CurrentLife <= playerDyingLifeThreshold)
			{
				UIController.PlayerIsDying();
			}
			
		}
		else 
		{
			KillPlayer();
		}

	}

	public void CostMana(float amount)
	{
		playerAttribute.CurrentMana -= amount;
		UIController.UpdateManaBar();
	}

	private void RegenerateMana()
	{
		playerAttribute.CurrentMana +=  playerAttribute.ManaRegenSpeed * Time.deltaTime;
		UIController.UpdateManaBar();
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
		invincibleAnime.SetActive(false);
	}

}
