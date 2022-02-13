using System.Collections;
using System.Collections.Generic;

public class Player : AbstractUnit
{
    public Player()
    {
        MaxLife = Constants.PlayerDefaultMaxLife;
        CurrentLife = MaxLife;
        MoveSpeed = Constants.PlayerDefaultMoveSpeed;
        Armour = Constants.PlayerDefaultArmour;
    }

    public Player(int maxLife, int currentLife)
    {
        this.MaxLife = maxLife;
        this.CurrentLife = currentLife;
        MoveSpeed = Constants.PlayerDefaultMoveSpeed;
        Armour = Constants.PlayerDefaultArmour;
    }

    public Player(int maxLife, int currentLife, float moveSpeed, int armour)
    {
        this.MaxLife = maxLife;
        this.CurrentLife = currentLife;
        this.MoveSpeed = moveSpeed;
        this.Armour = armour;
    }

}
