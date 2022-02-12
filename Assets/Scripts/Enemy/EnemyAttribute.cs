using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute
{
	// 敌人速度
	public float EnemyDefaultSpeed { set; get; } = 15;
	public float EnemySpeedRate { set; get; } = 1;

	// 敌人生效时间
	public float ActiveTime { set; get; } = 1;

	//是否处于激活状态，并可以移动对玩家造成伤害
	public bool IsActive { set; get; } = false;

	// 敌人生命值相关
	public float CurrentHealth { set; get; }
	public float TotalHealth { set; get; }
	public bool IsAlive { set; get; } = false;
	 


	public EnemyAttribute(float totalHealth, float activeTime) {
		ActiveTime = activeTime;
		
		TotalHealth = totalHealth;
		CurrentHealth = totalHealth;
		
		IsAlive = true;
	}

	// 敌人受到伤害调用该函数
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

	// 敌人受到治疗时调用该函数
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
