using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerAttribute playerAttribute = new PlayerAttribute();

    [SerializeField] private int playerMaxLife = Constants.PlayerDefaultMaxLife;
    [SerializeField] private int playerArmour = Constants.PlayerDefaultArmour;
    [SerializeField] private float playerBaseMoveSpeed = Constants.PlayerDefaultMoveSpeed;
    [SerializeField] private float playerBaseManaRegenSpeed = Constants.PlayerDefaultManaRegenSpeed;

    [SerializeField] private int playerDyingLifeThreshold = 3;


    [SerializeField] private float invincibleTime = 2f;
    [SerializeField] private GameObject invincibleAnime;
    private bool isInvincible = false;

    [SerializeField] private HitEffectGenerator hitEffectGenerator;

    private BattleSceneMainUIController UIController;

    private new PlayerAnimeController animation;

    private void Start()
    {
        InitPlayer();
        hitEffectGenerator = Utils.GetHitEffectGenerator();
    }

    private void Update()
    {
        RegenerateMana();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInvincible)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

                if (enemyController.enemyAttribute.IsActive)
                {
                    DamagePlayer(enemyController.damageToPlayer);

                    hitEffectGenerator.InitHitEffect(enemyController.GetEnemyElementType(), transform.position);
                    // Enemy Play dying animation
                    enemyController.KillEnemyWithoutPoint();
                }
            }
        }
    }

    public void InitPlayer()
    {
        playerAttribute.MaxLife = playerMaxLife;
        playerAttribute.CurrentLife = playerMaxLife;
        playerAttribute.Armour = playerArmour;
        playerAttribute.BaseMoveSpeed = playerBaseMoveSpeed;
        playerAttribute.BaseManaRegenSpeed = playerBaseManaRegenSpeed;

        animation = GameObject.FindGameObjectWithTag("PlayerAnimation").GetComponent<PlayerAnimeController>();
        UIController = GameObject.FindGameObjectWithTag("MainUI").GetComponent<BattleSceneMainUIController>();

    }

    public void DamagePlayer(int damage)
    {
        playerAttribute.CurrentLife -= damage;

        // UI update
        UIController.UpdateLifeBar();

        // UI shark
        UIController.GetDamage();

        if (playerAttribute.IsAlive)
        {
            // Anime
            animation.PlayerGetDamage();

            // Invincible
            isInvincible = true;
            invincibleAnime.SetActive(true);
            Invoke(nameof(ResetIincible), invincibleTime);

            // Is player dying
            if (playerAttribute.CurrentLife <= playerDyingLifeThreshold)
            {
                UIController.PlayerIsDying();
            }

        }
        else
        {
            KillPlayer();
        }

    }

    public void CostMana(float amount)
    {
        playerAttribute.CurrentMana -= amount;
        UIController.UpdateManaBar();
    }

    private void RegenerateMana()
    {
        playerAttribute.CurrentMana += playerAttribute.ManaRegenSpeed * Time.deltaTime;
        UIController.UpdateManaBar();
    }

    public void KillPlayer()
    {
        Debug.Log("Player Dead!");
        playerAttribute.IsActive = false;

        animation.PlayerIsDead();
    }

    private void ResetIincible()
    {
        isInvincible = false;
        invincibleAnime.SetActive(false);
    }

    /// <summary>
    /// Increase player's speed in a short time
    /// </summary>
    /// <param name="multiplier"></param>
    /// <param name="duration"></param>
    public void TemporarySpeedUp(float multiplier, float duration)
    {
        playerAttribute.SpeedMultiplier = multiplier;
        Invoke(nameof(ResetSpeed), duration);
    }

    public void TemporaryDamageIncrease(float multiplier, float duration)
    {
        playerAttribute.DamageMultiplier = multiplier;
        Invoke(nameof(ResetDamage), duration);
    }

    public void TemporaryManaRegenSpeedUp(float multiplier, float duration)
    {
        playerAttribute.ManaRegenSpeedMultiplier = multiplier;
        Invoke(nameof(ResetManaRegen), duration);
    }

    private void ResetSpeed()
    {
       playerAttribute.SpeedMultiplier = 1f;
    }
    
    private void ResetDamage()
    {
        playerAttribute.DamageMultiplier = 1f;
    }

    private void ResetManaRegen()
    {
        playerAttribute.ManaRegenSpeedMultiplier = 1f;
    }

    public void SetPlayerActive()
    {
        playerAttribute.IsActive = true;
    }
}

