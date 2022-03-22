using System;
using UnityEngine;

public class SpellDamageDealer
{
	public static PlayerAttribute PlayerAttribute = Utils.GetPlayerAttribute();
	public static void Deal(ElementType spellElementType, GameObject enemy, float amount)
	{
		EnemyController enemyController = enemy.GetComponent<EnemyController>();

		if (enemyController == null)
		{
			Debug.LogError("Enemy controller not found on given game object");
			return;
		}

		float multiplier = ElementDamageMultiplierCalculator.Get(spellElementType, enemyController.enemyAttribute.ElementType);

		int definitiveDamage = (int)Math.Round(amount * multiplier * (1 + PlayerAttribute.DamageBaseMultiplier));

		// Debug.Log("Raw damage " + amount);
		// Debug.Log("Multiplier " + multiplier);
		// Debug.Log("Enemy type " + enemyController.enemyAttribute.ElementType);
		// Debug.Log("Deal " + definitiveDamage + " damage to " + enemyController.enemyAttribute.GetHashCode());

		enemyController.DamageEnemy(definitiveDamage);

	}

}