using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButtonController : MonoBehaviour
{
	[SerializeField] private Constants.UpdateType updateType;

	[SerializeField] private GameObject levelUp;
	[SerializeField] private GameObject levelMax;

	[SerializeField] private LevelUpMainUIController mainUIController;

	[SerializeField] private Text needGoldText;
	[SerializeField] private Text nextLevelText;

	[SerializeField] private int nextLv = 1;
	[SerializeField] private int MaxLv = 5;

	private int currentGold = 0;
	private int currentchar;

	private void Awake()
	{
		currentchar = Utils.GetDataRecord().currentCharactorNum;
		if (PlayerPrefs.GetInt("char" + currentchar + Constants.UpdateData[updateType]) != 0)
		{
			nextLv = PlayerPrefs.GetInt("char" + currentchar + Constants.UpdateData[updateType]);
		}
		if (nextLv <= MaxLv)
		{
			levelUp.SetActive(true);
			levelMax.SetActive(false);
			UpdateUINum();
		}
		else 
		{
			levelUp.SetActive(false);
			levelMax.SetActive(true);
		}
		
	}

	/// <summary>
	/// for onClick
	/// </summary>
	public void LevelUp()
	{

		if (nextLv <= MaxLv)
		{
			int lastGold = PlayerPrefs.GetInt(Constants.CurrentGold) - currentGold;

			if (lastGold >= 0)
			{
				nextLv++;
				PlayerPrefs.SetInt(Constants.UpdateData[updateType], nextLv);
				UpdateUINum();

				if (nextLv > MaxLv)
				{
					levelUp.SetActive(false);
					levelMax.SetActive(true);
				}

				PlayerPrefs.SetInt(Constants.CurrentGold, lastGold);
				mainUIController.UpdateGold();
			}
		}
	}



	private void UpdateUINum()
	{
		currentGold = Utils.CalculateGold(nextLv);
		needGoldText.text = string.Format("{0:D3}", currentGold);
		nextLevelText.text = string.Format("{0:D2}", nextLv);
	}

}
