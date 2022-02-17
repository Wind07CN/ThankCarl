public abstract class AbstractUnit : IUnit
{
	private int mMaxLife;
	public int MaxLife
	{
		get { return mMaxLife; }
		set
		{
			if (value < 0)
			{
				throw new System.ArgumentException("Life cannot be negative");
			}
			else
			{
				mMaxLife = value;
			}
		}
	}
	private int mCurrentLife;
	public int CurrentLife
	{
		get { return mCurrentLife; }
		set
		{
			if (value > MaxLife)
			{
				mCurrentLife = MaxLife;
			}
			else if (value < 0)
			{
				mCurrentLife = 0;
			}
			else
			{
				mCurrentLife = value;
			}
		}
	}
	public float MoveSpeed { get; set; }
	public int Armour { get; set; }

	public bool IsAlive
	{
		get 
		{ 
			return mCurrentLife > 0; 
		}
	}

	private bool mIsActive;

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