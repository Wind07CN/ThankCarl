using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	private PlayerAttribute playerAttribute;
	private List<ElementType> conjuredElements = new List<ElementType>();
	private List<ElementType> spellElements = new List<ElementType>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

			// Debug.Log("Boom!!!!!!");
			DamagePlayer();

			// 由敌人自己控制结束, 同时由敌人处理死亡动画等等
			enemyController.KillEnemy();
		}
	}

	public void InitPlayer(PlayerAttribute playerAttribute)
	{
		// 一些准备工作完成,或者倒计时结束后后将控制权移交给玩家
		Debug.Log("Doing Something...");
		this.playerAttribute = playerAttribute;
		this.playerAttribute.IsActive = true;

		// Initialize UI
		UpdateLevelIndicatorUI();

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

    /*
	 * Level up player
	 */
	public void LevelUpPlayer()
	{
		playerAttribute.Level += 1;
	}

	public void UpdateLevelIndicatorUI()
	{
		GameObject.Find("PlayerLevel").GetComponent<Text>().text = "Lv." + playerAttribute.Level;
	}

	/*
	 * Conjure Elements
	 */
	public List<ElementType> GetConjuredElements()
	{
		return conjuredElements;
	}

	public List<ElementType> GetSpellElements()
	{
		return spellElements;
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

	public void PushConjuredElementsToSpell()
	{
		spellElements.Clear();
		spellElements.AddRange(conjuredElements);
	}

	public int GetConjuredElementsLimit()
	{
		return playerAttribute.Level + Constants.BaseConjuredElementsAmount - 1;
	}

	public bool IsConjureTableFull()
	{
		return conjuredElements.Count >= GetConjuredElementsLimit();
	}

	public bool IsConjureTableEmpty()
	{
		return conjuredElements.Count == 0;
	}
}
