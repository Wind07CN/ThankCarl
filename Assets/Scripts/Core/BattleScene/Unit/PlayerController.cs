using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	private PlayerAttribute playerAttribute;

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

	public void InitPlayer(PlayerAttribute playerAttribute)
	{
		// init
		Debug.Log("Doing Something...");
		this.playerAttribute = playerAttribute;
		this.playerAttribute.IsActive = true;

	}

	public void DamagePlayer()
	{
		playerAttribute.CurrentLife -= 1;
	}

	public void DamagePlayer(int damage)
	{
		playerAttribute.CurrentLife -= damage;
	}

	public void KillPlayer()
	{
		Debug.Log("Player Dead!");
		playerAttribute.IsActive = false;

		// play player dead animation
	}

}
