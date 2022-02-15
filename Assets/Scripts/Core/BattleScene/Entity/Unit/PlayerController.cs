using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerAttribute mPlayer;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

			Debug.Log("Boom!!!!!!");
			DamagePlayer();

			// 由敌人自己控制结束, 同时由敌人处理死亡动画等等
			enemyController.EnemyDead();
		}
	}

	public void InitPlayer(PlayerAttribute player)
	{
		// 一些准备工作完成,或者倒计时结束后后将控制权移交给玩家
		Debug.Log("Doing Something...");
		this.mPlayer = player;
		this.mPlayer.IsActive = true;

	}

	public void DamagePlayer()
	{
		mPlayer.CurrentLife -= 1;
	}

	public void DamagePlayer(int damage)
	{
		mPlayer.CurrentLife -= damage;
	}

	public void PlayerDead()
	{
		Debug.Log("Player Dead!");
		mPlayer.IsActive = false;

		//玩家死亡动画
	}

}
