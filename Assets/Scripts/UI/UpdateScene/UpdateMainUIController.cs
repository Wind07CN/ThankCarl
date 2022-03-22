using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMainUIController : MonoBehaviour
{
	[SerializeField] private Sprite[] skillIcons;
	[SerializeField] private Image charactorSkillIcon;
	
	[SerializeField] private int currentCharactorNum = 0;

	[SerializeField] private UpdateButtonController speedUpButton;
	[SerializeField] private UpdateButtonController lifeUpButton;
	[SerializeField] private UpdateButtonController manaMaxUpButton;
	[SerializeField] private UpdateButtonController manaRecoverUpButton;

	[SerializeField] private Text currentGoldText;
	[SerializeField] private Text currentUnlockText;

	[SerializeField] private Animator charactorAnimator;

	private void Awake()
	{
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt(Constants.CurrentGold, 990);

		charactorSkillIcon.sprite = skillIcons[currentCharactorNum];
		charactorAnimator.SetInteger("char", currentCharactorNum);

		UpdateGold();
	}

	public void UpdateGold() 
	{
		currentGoldText.text = string.Format("{0:D3}", PlayerPrefs.GetInt(Constants.CurrentGold));
	}

}
