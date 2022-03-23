using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUpMainUIController : MonoBehaviour
{
	[SerializeField] private Sprite[] skillIcons;
	[SerializeField] private Image charactorSkillIcon;

	[SerializeField] private int currentCharactorNum = 0;

	[SerializeField] private LevelButtonController speedUpButton;
	[SerializeField] private LevelButtonController lifeUpButton;
	[SerializeField] private LevelButtonController manaMaxUpButton;
	[SerializeField] private LevelButtonController manaRecoverUpButton;

	[SerializeField] private Text currentGoldText;
	[SerializeField] private Text currentUnlockSkillNumText;

	[SerializeField] private Animator charactorAnimator;

	private void Awake()
	{
		currentCharactorNum = Utils.GetDataRecord().currentCharactorNum;
		charactorSkillIcon.sprite = skillIcons[currentCharactorNum];
		charactorAnimator.SetInteger("char", currentCharactorNum);
		currentUnlockSkillNumText.text = string.Format("{0:D3}", PlayerPrefs.GetInt(Constants.LearnSkillNum)); 
		UpdateGold();
	}

	private void Update()
	{
		// For Testing
		if (Input.GetKey(KeyCode.A))
		{
			PlayerPrefs.SetInt(Constants.CurrentGold, 999);
			UpdateGold();
		}
		
	}

	public void UpdateGold()
	{
		currentGoldText.text = string.Format("{0:D3}", PlayerPrefs.GetInt(Constants.CurrentGold));
	}

	public void JumpToBattleScene()
	{
		Utils.GetDataRecord().NextSceneNum = Constants.BattleSceneTag;
		SceneManager.LoadScene(Constants.LoadingSceneTag);
	}

	public void JumpToChooseCharacterScene() 
	{
		Utils.GetDataRecord().NextSceneNum = Constants.CharChooseSceneTag;
		SceneManager.LoadScene(Constants.LoadingSceneTag);
	}
}
