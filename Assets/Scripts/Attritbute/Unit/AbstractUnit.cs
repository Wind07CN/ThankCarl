public abstract class AbstractUnit : IUnit
{
	private int maxLife;
	public int MaxLife
	{
		get { return maxLife; }
		set
		{
			if (value < 0)
			{
				throw new System.ArgumentException("Life cannot be negative");
			}
			else
			{
				maxLife = value;
			}
		}
	}
	private int currentLife;
	public int CurrentLife
	{
		get { return currentLife; }
		set
		{
			if (value > MaxLife)
			{
				currentLife = MaxLife;
			}
			else if (value < 0)
			{
				currentLife = 0;
			}
			else
			{
				currentLife = value;
			}
		}
	}
	public float MoveSpeed { get; set; }
	public int Armour { get; set; }

	public bool IsAlive
	{
		get 
		{ 
			return currentLife > 0; 
		}
	}

	private bool isActive;

/*	public bool IsActive
	{
		get { return mIsActive; }
		set
		{
			if (!IsAlive)
			{
				mIsActive = false;
			}
			else
			{
				mIsActive = value;
			}
		}
	}
*/
	public bool IsActive { set; get; }
}