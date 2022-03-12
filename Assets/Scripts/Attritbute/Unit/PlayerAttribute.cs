using System.Collections;
using System.Collections.Generic;

public class PlayerAttribute : AbstractUnit
{

	public int Experience { get; set; }
	public int Level { get; set; }
	private float currentMana;

	public float CurrentMana { 
		get { return currentMana; }
		set {
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

	public int MaxMana { get; set; }

	public int PlayerPoints { get; set; }

	// per second
	public float ManaRegenSpeed { get; set; }

	public PlayerAttribute()
	{
		MaxLife = Constants.PlayerDefaultMaxLife;
		CurrentLife = MaxLife;
		MoveSpeed = Constants.PlayerDefaultMoveSpeed;
		Armour = Constants.PlayerDefaultArmour;
		Level = 1;
		Experience = 0;
		PlayerPoints = 0;
		MaxMana = 100;
		CurrentMana = MaxMana;
		ManaRegenSpeed = 10;
	}

	public PlayerAttribute(int maxLife)
	{
		MaxLife = maxLife;
		CurrentLife = maxLife;
		MoveSpeed = Constants.PlayerDefaultMoveSpeed;
		Armour = Constants.PlayerDefaultArmour;
		Level = 1;
		Experience = 0;
		PlayerPoints = 0;
		MaxMana = 100;
		CurrentMana = MaxMana;
		ManaRegenSpeed = 10;
	}

	public PlayerAttribute(int maxLife, float moveSpeed, int armour)
	{
		MaxLife = maxLife;
		CurrentLife = maxLife;
		MoveSpeed = moveSpeed;
		Armour = armour;
		Level = 1;
		PlayerPoints = 0;
		MaxMana = 100;
		CurrentMana = MaxMana;
		ManaRegenSpeed = 10;
	}

	public PlayerAttribute(int maxLife, int maxMana, float moveSpeed, int armour, float manaRegenSpeed)
	{
		MaxLife = maxLife;
		CurrentLife = maxLife;
		MoveSpeed = moveSpeed;
		Armour = armour;
		Level = 1;
		PlayerPoints = 0;
		MaxMana = maxMana;
		CurrentMana = MaxMana;
		ManaRegenSpeed = manaRegenSpeed;
	}

}
