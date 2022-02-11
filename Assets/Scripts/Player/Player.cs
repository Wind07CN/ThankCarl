using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
	public float totalHealth { set; get; }
	public float currentHealth { set; get; }

	public bool isAlive { set; get; } = true;


	public Player(float totalHealth)
	{
		isAlive = true;
		this.totalHealth = totalHealth;
		this.currentHealth = totalHealth;
	}

	public void GetDamage(float demage)
	{
		if (currentHealth - demage <= 0f)
		{
			currentHealth = 0f;
			isAlive = false;
		}
		else
		{
			currentHealth -= demage;
		}
	}

	public void GetHeal(float heal)
	{
		if (currentHealth + heal > totalHealth)
		{
			currentHealth = totalHealth;
		}
		else
		{
			currentHealth += heal;
		}
	}

}
