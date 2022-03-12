using System;
using UnityEngine;

public class SpellDamageDealer
{
    public static void Deal(ElementType spellElementType, GameObject enemy, float amount)
    {
        EnemyController enemyController = enemy.GetComponent<EnemyController>();

        if (enemyController == null)
        {
            Debug.LogError("Enemy controller not found on given game object");
            return;
        }

        float multiplier = ElementDamageMultiplierCalculator.Get(spellElementType, enemyController.enemyAttribute.ElementType);

        int definitiveDamage = (int) Math.Round(amount * multiplier);

        enemyController.DamageEnemy(definitiveDamage);

    }
    
}