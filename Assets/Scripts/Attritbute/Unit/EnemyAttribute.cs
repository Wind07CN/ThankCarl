public class EnemyAttribute : AbstractUnit
{
    public ElementType ElementType { get; private set; }

    public EnemyAttribute(ElementType elementType)
    {
		ElementType = elementType;
        MaxLife = Constants.EnemyDefaultMaxLife;
        CurrentLife = MaxLife;
        MoveSpeed = Constants.EnemyDefaultMoveSpeed;
        Armour = Constants.EnemyDefaultArmour;
    }


    public EnemyAttribute(ElementType elementType, int maxLife, int currentLife)
    {
		ElementType = elementType;
        this.MaxLife = maxLife;
        this.CurrentLife = currentLife;
        MoveSpeed = Constants.EnemyDefaultMoveSpeed;
        Armour = Constants.EnemyDefaultArmour;
    }

    public EnemyAttribute(ElementType elementType, int maxLife, int currentLife, float moveSpeed, int armour)
    {
		ElementType = elementType;
        this.MaxLife = maxLife;
        this.CurrentLife = currentLife;
        this.MoveSpeed = moveSpeed;
        this.Armour = armour;
    }
}