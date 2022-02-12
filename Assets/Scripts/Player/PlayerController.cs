using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float playDefaultLife = 3;
	public float playerDefaultSpeed = 20;

	public Player player;
	private bool isDead = false;

	public void Start()
	{
		player = new Player(playDefaultLife, playerDefaultSpeed);
	}

	private void Update()
	{
		if (!isDead)
		{
			KeyBoardInput();

			if (!player.IsAlive)
			{
				
				Debug.Log("Player Dead!");
				isDead = true;

				// 通知所有敌人玩家已经阵亡
				foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
					enemy.GetComponent<EnemyController>().SetPlayerIsDead();
				}

			}
		}
	}



	private void KeyBoardInput()
	{
		float moveDistance = Time.deltaTime * player.PlayerDefaultSpeed * player.PlayerSpeedRate;

		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector2.up * moveDistance);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(-Vector2.up * moveDistance);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector2.left * moveDistance);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector2.right * moveDistance);
		}
	}

}
