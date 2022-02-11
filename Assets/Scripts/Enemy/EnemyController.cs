using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float enemyDefaultSpeed = 15;
	public float enemySpeedRate = 1;

	public float waitTime = 1;
	private float timer = 1;

	public bool isActive = false; //是否处于激活状态，并可以对玩家造成伤害

	private GameObject player;

	private Vector2 direction;

	private void Start()
	{
		timer = waitTime;

		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}

	private void Update()
	{
		if (!isActive)
		{
			CheckTimer();
		}
		else if (isActive)
		{
			direction = player.transform.position - transform.position;
			// Debug.Log(direction);
			// Debug.Log(-direction * enemyDefaultSpeed * enemySpeedRate);
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.Translate(Vector2.right * enemyDefaultSpeed * enemySpeedRate * Time.deltaTime);
		}
	}


	private void CheckTimer()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			isActive = true;
		}
	}
}
