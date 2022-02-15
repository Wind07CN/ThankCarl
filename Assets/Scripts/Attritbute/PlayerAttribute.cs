using System.Collections;
using System.Collections.Generic;

public class PlayerAttribute : AbstractUnit
{
	public PlayerAttribute()
	{
		MaxLife = Constants.PlayerDefaultMaxLife;
		CurrentLife = MaxLife;
		MoveSpeed = Constants.PlayerDefaultMoveSpeed;
		Armour = Constants.PlayerDefaultArmour;
	}

	public PlayerAttribute(int maxLife)
	{
		MaxLife = maxLife;
		CurrentLife = maxLife;
		MoveSpeed = Constants.PlayerDefaultMoveSpeed;
		Armour = Constants.PlayerDefaultArmour;
	}

	public PlayerAttribute(int maxLife,  float moveSpeed, int armour)
    {
        MaxLife = maxLife;
        CurrentLife = maxLife;
        MoveSpeed = moveSpeed;
        Armour = armour;
	}

}
