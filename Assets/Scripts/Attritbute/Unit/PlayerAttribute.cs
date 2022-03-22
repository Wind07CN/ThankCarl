using System.Collections;
using System.Collections.Generic;

public class PlayerAttribute : AbstractUnit
{
	public int CurrentSubElement { get; set; }

	private float currentMana;
	public float CurrentMana
	{
		get { return currentMana; }
		set
		{
			if (value > BaseMaxMana)
			{
				currentMana = BaseMaxMana;
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

	// Life
	public int MaxLifeLevel { get; set; }

	// Speed
	public float BaseMoveSpeed { get; set; }
	public int SpeedLevel { get; set; }
	public float SpeedMultiplier { get; set; }
	public float SpeedBaseMultiplier
	{
		get { return SpeedLevel * Constants.EachLevelAddSpeed; }
	}
	public new float MoveSpeed
	{
		get { return BaseMoveSpeed * (1 + SpeedMultiplier); }
	}

	// Damage
	public int DamageLevel { get; set; }
	public float DamageMultiplier { get; set; }
	public float DamageBaseMultiplier
	{
		get { return DamageLevel * Constants.EachLevelAddDamage; }
	}

	// per second
	public float BaseManaRegenSpeed { get; set; }
	public int ManaRegenSpeedLevel { get; set; }
	public float ManaRegenSpeedMultiplier { get; set; }
	public float ManaRegenSpeedBaseMultiplier
	{
		get { return ManaRegenSpeedLevel * Constants.EachLevelAddManaRegenSpeedLevel; }
	}
	public float ManaRegenSpeed
	{
		get { return BaseManaRegenSpeed * (1 + ManaRegenSpeedMultiplier); }
	}

	// Max Mana
	public int BaseMaxMana { get; set; }
	public int MaxManaLevel { get; set; }
	public float MaxManaMultiplier { get; set; }
	public float MaxManaBaseMultiplier
	{
		get { return MaxManaLevel * Constants.EachLevelAddMaxMana; }
	}
	public float MaxMana 
	{
		get { return BaseMaxMana * (1 + MaxManaMultiplier); }
	}

	public int PlayerPoints { get; set; }

	public PlayerAttribute()
	{

		DamageLevel = 0;
		// Life
		MaxLife = Constants.PlayerDefaultMaxLife;
		CurrentLife = MaxLife;

		BaseMoveSpeed = Constants.PlayerDefaultMoveSpeed;

		Armour = Constants.PlayerDefaultArmour;

		PlayerPoints = 0;
		BaseMaxMana = Constants.PlayerDefaultMaxMana;
		CurrentMana = BaseMaxMana;
		BaseManaRegenSpeed = Constants.PlayerDefaultManaRegenSpeed;
	}


}
