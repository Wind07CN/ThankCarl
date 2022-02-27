using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	[HideInInspector] public PlayerAttribute playerAttribute = new PlayerAttribute();

	[SerializeField] private int playerMaxLife = Constants.PlayerDefaultMaxLife;
	[SerializeField] private int playerArmour = Constants.PlayerDefaultArmour;
	[SerializeField] private float playerMoveSpeed = Constants.PlayerDefaultMoveSpeed;

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
		if (collision.gameObject.CompareTag("Enemy"))
		{
			EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

			DamagePlayer();

			// Enemy Play dying animation
			enemyController.KillEnemy();
		}
	}

	public void InitPlayer()
	{
		// init
		// Debug.Log("Doing Something...");
		// Debug.Log("Init Player Fin, ready to go");
		playerAttribute.MaxLife = playerMaxLife;
		playerAttribute.Armour = playerArmour;
		playerAttribute.MoveSpeed = playerMoveSpeed;

		animation = GameObject.FindGameObjectWithTag("PlayerAnimation").GetComponent<PlayerAnimeController>();
		// Set Active
		playerAttribute.IsActive = true;



	}

	public void DamagePlayer()
	{
		playerAttribute.CurrentLife -= 1;
		animation.PlayerGetDamage();
		
	}

	public void DamagePlayer(int damage)
	{
		playerAttribute.CurrentLife -= damage;
	}

	public void KillPlayer()
	{
		Debug.Log("Player Dead!");
		playerAttribute.IsActive = false;

		animation.PlayerIsDead();
	}

}
