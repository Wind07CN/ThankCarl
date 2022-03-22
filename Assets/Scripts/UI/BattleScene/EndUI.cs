using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
	[SerializeField] private Text finalPoint;
	[SerializeField] private Text currentGold;
	[SerializeField] private Text finalGold;

	private PlayerAttribute playerAttribute;

	private void Awake()
	{
		playerAttribute = Utils.GetPlayerAttribute();
		int point = playerAttribute.PlayerPoints;
		int gold = PlayerPrefs.GetInt(Constants.CurrentGold);
		
		finalPoint.text = string.Format("{0:D9}",point);
		currentGold.text = string.Format("{0:D3}", gold);
		
		gold += point / 100;
		gold = gold < 999 ? gold : 999;
		finalGold.text = string.Format("{0:D3}", gold);

		PlayerPrefs.SetInt(Constants.CurrentGold, gold);
	}

	public void JumpToLevelUpScene() 
	{
		Utils.GetDataRecord().NextSceneNum = Constants.LevelUpSceneTag;
		SceneManager.LoadScene(Constants.LoadingSceneTag);
	}


}
