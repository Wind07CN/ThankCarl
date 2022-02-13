public class Enemy: AbstractUnit
{
    public Enemy()
    {
        MaxLife = Constants.EnemyDefaultMaxLife;
        CurrentLife = MaxLife;
        MoveSpeed = Constants.EnemyDefaultMoveSpeed;
        Armour = Constants.EnemyDefaultArmour;
    }

    public Enemy(int maxLife, int currentLife)
    {
        this.MaxLife = maxLife;
        this.CurrentLife = currentLife;
        MoveSpeed = Constants.EnemyDefaultMoveSpeed;
        Armour = Constants.EnemyDefaultArmour;
    }

    public Enemy(int maxLife, int currentLife, float moveSpeed, int armour)
    {
        this.MaxLife = maxLife;
        this.CurrentLife = currentLife;
        this.MoveSpeed = moveSpeed;
        this.Armour = armour;
    }
}