using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{

	[HideInInspector] public PlayerAttribute playerAttribute;

	[SerializeField] private float EnemyLvUpTime = 60f;
	private float timer = 0f;
	public int EnemyLv = 0;

	private void Awake()
	{
		timer = EnemyLvUpTime;
	}

	private void Update()
	{
		if (timer <= 0) 
		{
			timer = EnemyLvUpTime;
			EnemyLv++;
		}

		timer -= Time.deltaTime;
	}








}
