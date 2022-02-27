using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSceneMainUIController : MonoBehaviour
{

	private PlayerAttribute playerAttribute;
	[SerializeField] private GameObject playerLevelIndicator;
	[SerializeField] private GameObject playerPointCounter;
	private Text playerLevelText;
	private Text playerPointCounterText;

	private void Start()
	{
		InitMainUI();
	}

	private void Update()
	{
		UpdatePlayerPointCounterUI();	
	}
	private void InitMainUI()
	{
		playerAttribute = Utils.GetPlayerAttribute();

		playerLevelText = playerLevelIndicator.GetComponent<Text>();
		playerPointCounterText = playerPointCounter.GetComponent<Text>();
	}

	public void UpdateLevelIndicatorUI()
	{
		playerLevelText.text = "Lv." + playerAttribute.Level;
	}

	public void UpdatePlayerPointCounterUI()
	{
		playerPointCounterText.text = "You Life" + playerAttribute.CurrentLife +"/" + playerAttribute.MaxLife;
	}








}
