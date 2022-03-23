using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeUIController : MonoBehaviour
{
	private void Awake()
	{
		InitData();
	}

	private void InitData() 
	{
		// Check if first Entry Game
		if (PlayerPrefs.GetInt("DataExist") == 1) 
		{
			return;
		}
		PlayerPrefs.SetInt("DataExist", 1);

		// Unlock Default Char
		PlayerPrefs.SetInt(Constants.Char + 1, 1);
		PlayerPrefs.SetInt(Constants.Char + 0, 0);
		PlayerPrefs.SetInt(Constants.Char + 2, 0);

		// Set Gold
		PlayerPrefs.SetInt(Constants.CurrentGold, 0);

		// Set Learn Skills Num
		PlayerPrefs.SetInt(Constants.LearnSkillNum, 0);
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.P))
		{
			PlayerPrefs.DeleteAll();
			InitData();
		}
	}

	public void ExitGame()
	{
		Debug.Log("Quit Game!");
		Application.Quit();
	}

	public void JumpToChooseCharScene()
	{
		Utils.GetDataRecord().NextSceneNum = Constants.CharChooseSceneTag;
		SceneManager.LoadScene(Constants.LoadingSceneTag);
	}
}
