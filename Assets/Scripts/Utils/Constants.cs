using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    // player
    public const int PlayerDefaultMaxLife = 100;
    public const float PlayerDefaultMoveSpeed = 10;
    public const int PlayerDefaultArmour = 0;
    public const float PlayerDefaultManaRegenSpeed = 5;

    // enemy
    public const int EnemyDefaultMaxLife = 30;
    public const float EnemyDefaultMoveSpeed = 5;
    public const int EnemyDefaultArmour = 0;
    public const float EnemyDefaultActiveTime = 1f;
    public const int NormalEnemyTypeDefaultNum = 0;
    public const int EliteEnemyTypeDefaultNum = 0;
    
    // spell
    public const int ElementManaCost = 5;
    public const float nextDefaultSpawnTime = 1f;
    public const float ElementDamageEnhanceMultiplier = 2f;
    public const float ElementDamageReduceMultiplier = 0.5f;
    // battlefield
    public const float BattlefieldDefaultMaxX = 14f;
    public const float BattlefieldDefaultMinX = -14f;
    public const float BattlefieldDefaultMaxY = 14;
    public const float BattlefieldDefaultMinY = -14f;

    public const float EliteDefaultRate = 0.1f;

    public const float DifficultyDefaultMultiplier = 1f;

    public const int BaseConjuredElementsAmount = 2;

    public const string PlayerTag = "Player";
    public const string EnemyTag = "Enemy";
    public const string MainUITag = "MainUI";
    public const string MainControllerTag = "MainController";

    public enum UpdateType
    {
        speedLv = 0,
        healthLv = 1,
        manaMaxLv = 2,
        manaRecoverLv = 3,
    }

    public static Dictionary<UpdateType, string> UpdateData = new Dictionary<UpdateType, string>()
    {
        {UpdateType.speedLv, "speedLv" },
        {UpdateType.healthLv, "healthLv" },
        {UpdateType.manaMaxLv, "manaMaxLv" },
        {UpdateType.manaRecoverLv, "manaRecoverLv" }
    };

    public const string CurrentGold = "CurrentGold";
}