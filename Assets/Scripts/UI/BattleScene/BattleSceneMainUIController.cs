using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSceneMainUIController : MonoBehaviour
{

	private PlayerAttribute playerAttribute;
	[SerializeField] private GameObject playerLevelIndicator;
	[SerializeField] private GameObject playerPointCounter;
	[SerializeField] private GameObject playerLifeBar;
	[SerializeField] private GameObject playerManaBar;
	private Text playerLevelText;
	private Text playerPointCounterText;
	private ManaBar manaBar;
	private LifeBar lifeBar;



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

		lifeBar = playerLifeBar.GetComponent<LifeBar>();
		manaBar = playerManaBar.GetComponent<ManaBar>();
	}

	public void UpdateLevelIndicatorUI()
	{
		playerLevelText.text = "Lv." + playerAttribute.Level;
	}

	public void UpdatePlayerPointCounterUI()
	{
		playerPointCounterText.text = "You Life" + playerAttribute.CurrentLife + "/" + playerAttribute.MaxLife;
	}

	public void UpdateManaBar()
	{
		manaBar.shouldUpdate = true;
	}

	public void UpdateLifeBar()
	{
		lifeBar.shouldUpdate = true;
	}





}
