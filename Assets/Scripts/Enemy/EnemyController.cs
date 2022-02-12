using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float enemyDefaultSpeed = 15;
	public float enemySpeedRate = 1;

	public float waitTime = 5f;

	public float enemyTotalHealth = 1f;
	public float enemyCurrentHealth = 1f;

	private GameObject player;

	// 玩家是否存活如果玩家死亡需要调用方法通知所有敌人
	private bool IsPlayerAlive = true;

	private Vector2 direction;

	private EnemyAttribute enemy;

	private void Start()
	{
		enemy = new EnemyAttribute(enemyCurrentHealth, waitTime);
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}

		Invoke("SetEnemyActive", enemy.ActiveTime); //延迟5秒激活敌人
	}

	private void Update()
	{
		if (enemy.IsActive && IsPlayerAlive)
		{
			direction = player.transform.position - transform.position;

			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // tan * 57.3 = angle
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.Translate(Vector2.right * enemyDefaultSpeed * enemySpeedRate * Time.deltaTime);
		}
	}

	private void SetEnemyActive()
	{
		enemy.IsActive = true;
	}

	public void SetPlayerIsDead() { 
		IsPlayerAlive = false;
	}


}
