using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelupUI : MonoBehaviour
{
	[SerializeField] private Sprite recoverHealthSprite;
	[SerializeField] private Sprite addDamageSprite;
	[SerializeField] private Sprite addSpeedSprite;
	[SerializeField] private Sprite addManaMaxLimitSprite;
	[SerializeField] private Sprite addManaRecoverSpeedSprite;
	[SerializeField] private Sprite addNewElementSprite;

	private Dictionary<BuffType, Sprite> buffSpriteDic = new Dictionary<BuffType, Sprite>();

	[SerializeField] private Button[] buttons;
	[SerializeField] private Image[] images;

	private BattleSceneMainUIController mainUIController;

	private BuffType[] buttonBuff = new BuffType[3];

	private Animator animator;

	private PlayerAttribute playerAttribute;

	public int levelupNotChooseTime = 0;
	public int restOfUnchooseAddElement = 0;
	private bool isActive = false;


	private static List<BuffType> normalBuff = new List<BuffType>()
	{
		BuffType.RecoverHealth,
		BuffType.AddDamage,
		BuffType.AddSpeed,
		BuffType.AddManaMaxLimit,
		BuffType.AddManaRecoverSpeed
	};

	public enum BuffType
	{
		RecoverHealth = 0,
		AddDamage = 1,
		AddSpeed = 2,
		AddManaMaxLimit = 3,
		AddManaRecoverSpeed = 4,
		AddNewElement = 5,
	}

	private void Start()
	{
		InitSpriteDic();
		animator = GetComponent<Animator>();
		playerAttribute = Utils.GetPlayerAttribute();
		mainUIController = Utils.GetMainUIController();
		UpdateBuff(restOfUnchooseAddElement > 0);
	}

	private void Update()
	{
		if (levelupNotChooseTime > 0 && !isActive)
		{
			// Pop-up option box
			animator.SetBool("isActive", true);
			animator.SetBool("levelUp", true);
			isActive = true;
		}
		if (levelupNotChooseTime < 0 && isActive) 
		{
			isActive = false;
			animator.SetBool("levelUp", false);
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (restOfUnchooseAddElement + playerAttribute.CurrentSubElement < Constants.MaxSubElementsCount) 
			{
				playerAttribute.CurrentSubElement++;
				mainUIController.Addconjure();
				Utils.GetMainUIController().ShowGetNewElementUI();
			}
			
		}
	}

	private void InitSpriteDic()
	{
		buffSpriteDic.Clear();
		buffSpriteDic.Add(BuffType.RecoverHealth, recoverHealthSprite);
		buffSpriteDic.Add(BuffType.AddDamage, addDamageSprite);
		buffSpriteDic.Add(BuffType.AddSpeed, addSpeedSprite);
		buffSpriteDic.Add(BuffType.AddManaMaxLimit, addManaMaxLimitSprite);
		buffSpriteDic.Add(BuffType.AddManaRecoverSpeed, addManaRecoverSpeedSprite);
		buffSpriteDic.Add(BuffType.AddNewElement, addNewElementSprite);
	}

	public void GetButtonInput(int buttonNum)
	{
		// Prevent the player from clicking while the animation is retracted
		if (!isActive)
		{
			return;
		}

		levelupNotChooseTime--;
		if (levelupNotChooseTime == 0)
		{
			isActive = false;
			animator.SetBool("levelUp", false);
		}
		else if (levelupNotChooseTime <= 0)
		{
			throw new System.Exception("Unexpecteded error: the Counter of rest Levelup select is under 0!");
		}

		HandleButtonInput(buttonBuff[buttonNum]);
		UpdateBuff(restOfUnchooseAddElement > 0);
	}

	private void HandleButtonInput(BuffType buttonBuff)
	{
		switch (buttonBuff)
		{
			case BuffType.RecoverHealth:
				playerAttribute.CurrentLife += 3;
				mainUIController.UpdateLifeBar();
				break;
			case BuffType.AddDamage:
				playerAttribute.DamageLevel++;
				playerAttribute.DamageMultiplier = playerAttribute.DamageBaseMultiplier;
				break;
			case BuffType.AddSpeed:
				playerAttribute.SpeedLevel++;
				playerAttribute.SpeedMultiplier = playerAttribute.SpeedBaseMultiplier;
				break;
			case BuffType.AddManaMaxLimit:
				playerAttribute.MaxManaLevel++;
				playerAttribute.MaxManaMultiplier = playerAttribute.MaxManaBaseMultiplier;
				mainUIController.UpdateManaBar();
				break;
			case BuffType.AddManaRecoverSpeed:
				playerAttribute.ManaRegenSpeedLevel++;
				playerAttribute.ManaRegenSpeedMultiplier = playerAttribute.ManaRegenSpeedBaseMultiplier;
				mainUIController.UpdateManaBar();
				break;
			case BuffType.AddNewElement:
				playerAttribute.CurrentSubElement++;
				mainUIController.Addconjure();
				if (playerAttribute.CurrentSubElement > Constants.MaxSubElementsCount)
				{
					throw new System.Exception("Unexpecteded error: the SubElementsCount is bigger than limit");
				}
				Utils.GetMainUIController().ShowGetNewElementUI();
				restOfUnchooseAddElement--;
				break;
			default:
				throw new System.Exception("The buff is not legal, check the buffType.");
		}
	}

	private void UpdateBuff(bool hasGetNewElement)
	{
		// Use the shuffle algorithm for random buff
		List<BuffType> tempList = new List<BuffType>()
		{
			BuffType.RecoverHealth,
			BuffType.AddDamage,
			BuffType.AddSpeed,
			BuffType.AddManaMaxLimit,
			BuffType.AddManaRecoverSpeed
		};
		

		Utils.ListRandom(tempList);

		buttonBuff[0] = hasGetNewElement ? BuffType.AddNewElement : tempList[2];
		buttonBuff[1] = tempList[0];
		buttonBuff[2] = tempList[1];
		UpdateBuffIcon();
	}



	private void UpdateBuffIcon()
	{
		for (int i = 0; i < images.Length; i++)
		{
			images[i].sprite = buffSpriteDic[buttonBuff[i]];
		}
	}

	public void StartChooseBuff(bool hasElementAdd)
	{
		if (hasElementAdd && restOfUnchooseAddElement + playerAttribute.CurrentSubElement < Constants.MaxSubElementsCount)
		{
			restOfUnchooseAddElement++;
		}
		levelupNotChooseTime++;
	}
}
