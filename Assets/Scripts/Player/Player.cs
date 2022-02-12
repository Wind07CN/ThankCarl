using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
	// 玩家速度
	public float PlayerDefaultSpeed { set; get; } = 20;
	public float PlayerSpeedRate { set; get; } = 1;
	


	// 玩家生命值相关
	public float TotalHealth { set; get; }
	public float CurrentHealth { set; get; }



	// 玩家是否存活
	public bool IsAlive { set; get; } = true;

	// 构造函数
	public Player(float totalHealth, float playerDefaultSpeed)
	{
		IsAlive = true;
		this.PlayerDefaultSpeed = playerDefaultSpeed;
		this.TotalHealth = totalHealth;
		this.CurrentHealth = totalHealth;
	}

	// 在玩家受到伤害的时候 由敌人调用该函数
	public void GetDamage(float demage)
	{
		if (CurrentHealth - demage <= 0f)
		{
			CurrentHealth = 0f;
			IsAlive = false;
		}
		else
		{
			CurrentHealth -= demage;
		}
	}

	// 玩家受到治疗时调用该函数
	public void GetHeal(float heal)
	{
		if (CurrentHealth + heal > TotalHealth)
		{
			CurrentHealth = TotalHealth;
		}
		else
		{
			CurrentHealth += heal;
		}
	}

}
