public class EnemyAttribute : AbstractUnit
{
    public EnemyAttribute()
    {
        MaxLife = Constants.EnemyDefaultMaxLife;
        CurrentLife = MaxLife;
        MoveSpeed = Constants.EnemyDefaultMoveSpeed;
        Armour = Constants.EnemyDefaultArmour;
    }


	public EnemyAttribute(int maxLife, int currentLife)
	{
		this.MaxLife = maxLife;
		this.CurrentLife = currentLife;
		MoveSpeed = Constants.EnemyDefaultMoveSpeed;
		Armour = Constants.EnemyDefaultArmour;
	}

	public EnemyAttribute(int maxLife, int currentLife, float moveSpeed, int armour)
	{
		this.MaxLife = maxLife;
		this.CurrentLife = currentLife;
		this.MoveSpeed = moveSpeed;
		this.Armour = armour;
	}
}