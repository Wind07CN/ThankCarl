using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharactorUIController : MonoBehaviour
{
	[SerializeField] private Button[] CharsButton;
	[SerializeField] private Sprite unlockedStateSprite;
	[SerializeField] private Sprite lockedStateSprite;

	[SerializeField] private Text goldText;
	[SerializeField] private Text learnedSkillText;
	private bool[] unlockState = new bool[3];

	private void Start()
	{
		for (int i = 0; i < 3; i++)
		{
			unlockState[i] = PlayerPrefs.GetInt(Constants.Char + i) == 1;
			CharsButton[i].GetComponent<Image>().sprite = unlockState[i] ? unlockedStateSprite :lockedStateSprite;
		}
		learnedSkillText.text = string.Format("{0:D3}", PlayerPrefs.GetInt(Constants.LearnSkillNum));
	}

	private void Update()
	{
		// For Testing
		if (Input.GetKey(KeyCode.A))
		{
			PlayerPrefs.SetInt(Constants.CurrentGold, 999);
		}
		UpdateGold();
	}

	private void UpdateGold() 
	{
		goldText.text = string.Format("{0:D3}", PlayerPrefs.GetInt(Constants.CurrentGold)); 
	}

	public void HandleButtonInput(int buttonId) 
	{
		if (unlockState[buttonId])
		{
			Utils.GetDataRecord().currentCharactorNum = buttonId;
			Utils.GetDataRecord().NextSceneNum = Constants.LevelUpSceneTag;
			SceneManager.LoadScene(Constants.LoadingSceneTag);
		}
		else if (!unlockState[buttonId] && PlayerPrefs.GetInt(Constants.CurrentGold) >= 300) 
		{
			CharsButton[buttonId].GetComponent<Image>().sprite = unlockedStateSprite;
			unlockState[buttonId] = true;

			PlayerPrefs.SetInt(Constants.Char + buttonId, 1);
			PlayerPrefs.SetInt(Constants.CurrentGold, PlayerPrefs.GetInt(Constants.CurrentGold) - 300); 
			UpdateGold();
		}
	}


}

