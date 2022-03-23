using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
	[SerializeField] private Constants.LevelType updateType;

	[SerializeField] private GameObject levelUp;
	[SerializeField] private GameObject levelMax;

	[SerializeField] private LevelUpMainUIController mainUIController;

	[SerializeField] private Text needGoldText;
	[SerializeField] private Text nextLevelText;

	[SerializeField] private int CurrentLv = 1;
	[SerializeField] private int MaxLv = 5;
	private string stringForCheck;

	private int currentGold = 0;
	private int currentchar = 0;

	private void Awake()
	{
		currentchar = Utils.GetDataRecord().currentCharactorNum;
		stringForCheck = Constants.Char + currentchar + Constants.LevelTypeString[updateType];
		if (PlayerPrefs.GetInt(stringForCheck) >= 1)
		{
			CurrentLv = PlayerPrefs.GetInt(stringForCheck);
		}
		else 
		{
			// init Data
			PlayerPrefs.SetInt(stringForCheck, 1);
			CurrentLv = 1;
		}

		// InitUI
		if (CurrentLv <= MaxLv)
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

		if (CurrentLv <= MaxLv)
		{
			int lastGold = PlayerPrefs.GetInt(Constants.CurrentGold) - currentGold;

			if (lastGold >= 0)
			{
				CurrentLv++;
				PlayerPrefs.SetInt(stringForCheck, CurrentLv);
				UpdateUINum();

				if (CurrentLv > MaxLv)
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
		currentGold = Utils.CalculateGold(CurrentLv);
		needGoldText.text = string.Format("{0:D3}", currentGold);
		nextLevelText.text = string.Format("{0:D2}", CurrentLv);
	}

}
