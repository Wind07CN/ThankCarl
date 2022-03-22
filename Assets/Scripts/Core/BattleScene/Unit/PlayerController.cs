using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	[HideInInspector] public PlayerAttribute playerAttribute = new PlayerAttribute();

	[SerializeField] private int playerMaxLife = Constants.PlayerDefaultMaxLife;
	[SerializeField] private int playerArmour = Constants.PlayerDefaultArmour;
	[SerializeField] private float playerBaseMoveSpeed = Constants.PlayerDefaultMoveSpeed;
	[SerializeField] private float playerBaseManaRegenSpeed = Constants.PlayerDefaultManaRegenSpeed;

	[SerializeField] private int playerDyingLifeThreshold = 3;


	[SerializeField] private float invincibleTime = 2f;
	[SerializeField] private GameObject invincibleAnime;
	private bool isInvincible = false;

	[SerializeField] private HitEffectGenerator hitEffectGenerator;

	private BattleSceneMainUIController UIController;

	private new PlayerAnimeController animation;

	private void Awake()
	{
		InitPlayer();
		hitEffectGenerator = Utils.GetHitEffectGenerator();
		UIController = Utils.GetMainUIController();
	}
	private void Start()
	{
		UIController.UpdateAllUI();
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

					hitEffectGenerator.InitHitEffect(enemyController.GetEnemyElementType(), transform.position);
					// Enemy Play dying animation
					enemyController.KillEnemyWithoutPoint();
				}
			}
		}
	}

	public void InitPlayer()
	{
		/*        // Init Multiplier
				playerAttribute.MaxLifeLevel = PlayerPrefs.GetInt("MaxLifeLevel"); 
				playerAttribute.SpeedLevel = PlayerPrefs.GetInt("SpeedLevel"); 
				playerAttribute.MaxManaLevel = PlayerPrefs.GetInt("MaxManaLevel");
				playerAttribute.ManaRegenSpeedLevel = PlayerPrefs.GetInt("ManaRegenSpeedLevel");
				playerAttribute.CurrentSubElement = PlayerPrefs.GetInt("CurrentSubElement");*/

		playerAttribute.MaxLifeLevel = 1;
		playerAttribute.SpeedLevel = 0;
		playerAttribute.MaxManaLevel = 0;
		playerAttribute.ManaRegenSpeedLevel = 0;
		playerAttribute.CurrentSubElement = 1;

		// Init Multiplier
		playerAttribute.SpeedMultiplier = playerAttribute.SpeedBaseMultiplier;
		playerAttribute.MaxManaMultiplier = playerAttribute.MaxManaBaseMultiplier;
		playerAttribute.ManaRegenSpeedMultiplier = playerAttribute.MaxManaBaseMultiplier;
		playerAttribute.DamageMultiplier = playerAttribute.DamageBaseMultiplier;

		// Init Life and MaxMana
		playerAttribute.MaxLife = playerMaxLife + playerAttribute.MaxLifeLevel;
		playerAttribute.CurrentLife = playerAttribute.MaxLife;
		playerAttribute.CurrentMana = playerAttribute.MaxMana;

		playerAttribute.Armour = playerArmour;
		playerAttribute.BaseMoveSpeed = playerBaseMoveSpeed;
		playerAttribute.BaseManaRegenSpeed = playerBaseManaRegenSpeed;

		animation = GameObject.FindGameObjectWithTag("PlayerAnimation").GetComponent<PlayerAnimeController>();
		UIController = GameObject.FindGameObjectWithTag("MainUI").GetComponent<BattleSceneMainUIController>();

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
		playerAttribute.CurrentMana += playerAttribute.ManaRegenSpeed * Time.deltaTime;
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

	/// <summary>
	/// Increase player's speed in a short time
	/// </summary>
	/// <param name="multiplier"></param>
	/// <param name="duration"></param>
	public void TemporarySpeedUp(float multiplier, float duration)
	{
		playerAttribute.SpeedMultiplier += multiplier;
		Invoke(nameof(ResetSpeed), duration);
	}

	public void TemporaryDamageIncrease(float multiplier, float duration)
	{
		playerAttribute.DamageMultiplier += multiplier;
		Invoke(nameof(ResetDamage), duration);
	}

	public void TemporaryManaRegenSpeedUp(float multiplier, float duration)
	{
		playerAttribute.ManaRegenSpeedMultiplier += multiplier;
		Invoke(nameof(ResetManaRegen), duration);
	}

	private void ResetSpeed()
	{
		playerAttribute.SpeedMultiplier = playerAttribute.SpeedBaseMultiplier;
	}

	private void ResetDamage()
	{
		playerAttribute.DamageMultiplier = playerAttribute.DamageBaseMultiplier;
	}

	private void ResetManaRegen()
	{
		playerAttribute.ManaRegenSpeedMultiplier = playerAttribute.ManaRegenSpeedBaseMultiplier;
	}

	public void SetPlayerActive()
	{
		playerAttribute.IsActive = true;
	}
}

