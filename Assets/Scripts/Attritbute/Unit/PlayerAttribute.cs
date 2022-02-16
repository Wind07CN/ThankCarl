using System.Collections;
using System.Collections.Generic;

public class PlayerAttribute : AbstractUnit
{

	public int Experience { get; set; }
	public int Level { get; set; }
	public PlayerAttribute()
	{
		MaxLife = Constants.PlayerDefaultMaxLife;
		CurrentLife = MaxLife;
		MoveSpeed = Constants.PlayerDefaultMoveSpeed;
		Armour = Constants.PlayerDefaultArmour;
		Level = 1;
		Experience = 0;
	}

	public PlayerAttribute(int maxLife)
	{
		MaxLife = maxLife;
		CurrentLife = maxLife;
		MoveSpeed = Constants.PlayerDefaultMoveSpeed;
		Armour = Constants.PlayerDefaultArmour;
		Level = 1;
		Experience = 0;
	}

	public PlayerAttribute(int maxLife,  float moveSpeed, int armour)
    {
        MaxLife = maxLife;
        CurrentLife = maxLife;
        MoveSpeed = moveSpeed;
        Armour = armour;
		Level = 1;
	}

}