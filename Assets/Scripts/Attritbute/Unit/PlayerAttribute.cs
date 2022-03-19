using System.Collections;
using System.Collections.Generic;

public class PlayerAttribute : AbstractUnit
{

    public int Experience { get; set; }
    public int Level { get; set; }
    private float currentMana;

    public float CurrentMana
    {
        get { return currentMana; }
        set
        {
            if (value > MaxMana)
            {
                currentMana = MaxMana;
            }
            else if (value < 0)
            {
                currentMana = 0;
            }
            else
            {
                currentMana = value;
            }
        }
    }

    public float SpeedMultiplier = 1f;
    public float DamageMultiplier = 1f;
    public float ManaRegenSpeedMultiplier = 1f;

    public int MaxMana { get; set; }

    public int PlayerPoints { get; set; }

    public float BaseMoveSpeed { get; set; }
	public new float MoveSpeed
	{
		get { return BaseMoveSpeed * SpeedMultiplier; }
	}

    // per second
    public float BaseManaRegenSpeed { get; set; }
    public float ManaRegenSpeed	
	{
		get { return BaseManaRegenSpeed * ManaRegenSpeedMultiplier; }
	}

    public PlayerAttribute()
    {
        MaxLife = Constants.PlayerDefaultMaxLife;
        CurrentLife = MaxLife;
        BaseMoveSpeed = Constants.PlayerDefaultMoveSpeed;
        Armour = Constants.PlayerDefaultArmour;
        Level = 1;
        Experience = 0;
        PlayerPoints = 0;
        MaxMana = 100;
        CurrentMana = MaxMana;
        BaseManaRegenSpeed = 10;
    }

    public PlayerAttribute(int maxLife)
    {
        MaxLife = maxLife;
        CurrentLife = maxLife;
        BaseMoveSpeed = Constants.PlayerDefaultMoveSpeed;
        Armour = Constants.PlayerDefaultArmour;
        Level = 1;
        Experience = 0;
        PlayerPoints = 0;
        MaxMana = 100;
        CurrentMana = MaxMana;
        BaseManaRegenSpeed = 10;
    }

    public PlayerAttribute(int maxLife, float moveSpeed, int armour)
    {
        MaxLife = maxLife;
        CurrentLife = maxLife;
        BaseMoveSpeed = moveSpeed;
        Armour = armour;
        Level = 1;
        PlayerPoints = 0;
        MaxMana = 100;
        CurrentMana = MaxMana;
        BaseManaRegenSpeed = 10;
    }

    public PlayerAttribute(int maxLife, int maxMana, float moveSpeed, int armour, float manaRegenSpeed)
    {
        MaxLife = maxLife;
        CurrentLife = maxLife;
        BaseMoveSpeed = moveSpeed;
        Armour = armour;
        Level = 1;
        PlayerPoints = 0;
        MaxMana = maxMana;
        CurrentMana = MaxMana;
        BaseManaRegenSpeed = manaRegenSpeed;
    }

}
