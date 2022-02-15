﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerAttribute playerAttribute;
	private List<ElementType> conjuredElements = new List<ElementType>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

			Debug.Log("Boom!!!!!!");
			DamagePlayer();

			// 由敌人自己控制结束, 同时由敌人处理死亡动画等等
			enemyController.KillEnemy();
		}
	}

	public void InitPlayer(PlayerAttribute player)
	{
		// 一些准备工作完成,或者倒计时结束后后将控制权移交给玩家
		Debug.Log("Doing Something...");
		this.playerAttribute = player;
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

		//玩家死亡动画
	}

	public void LevelUpPlayer()
	{
		playerAttribute.Level += 1;
	}

	/*
	 * Conjure Elements
	 */
	public List<ElementType> GetConjuredElements()
	{
		return conjuredElements;
	}

	public void AppendElement(ElementType element)
	{
		if (conjuredElements.Count < GetConjuredElementsLimit())
		{
			conjuredElements.Add(element);
		} else {
			throw new System.Exception("Conjured Elements is full!");
		}
	}

	public void ClearConjuredElements()
	{
		conjuredElements.Clear();
	}

	public int GetConjuredElementsLimit()
	{
		return playerAttribute.Level + Constants.BaseConjuredElementsAmount - 1;
	}

	public bool IsConjuredTableFull()	{
		return conjuredElements.Count >= GetConjuredElementsLimit();
	}

}
