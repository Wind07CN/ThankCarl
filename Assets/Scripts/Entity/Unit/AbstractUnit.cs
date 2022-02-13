public abstract class AbstractUnit : IUnit
{
    private int _maxLife;
    public int MaxLife
    {
        get { return _maxLife; }
        set
        {
            if (value < 0)
            {
                throw new System.ArgumentException("Life cannot be negative");
            }
            else
            {
                _maxLife = value;
            }
        }
    }
    private int _currentLife;
    public int CurrentLife
    {
        get { return _currentLife; }
        set
        {
            if (value > MaxLife)
            {
                _currentLife = MaxLife;
            }
            else if (value < 0)
            {
                _currentLife = 0;
            }
            else
            {
                _currentLife = value;
            }
        }
    }
    public float MoveSpeed { get; set; }
    public int Armour { get; set; }

    public bool IsAlive
    {
        get { return CurrentLife > 0; }
    }
}