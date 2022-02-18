using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

	private int countNum = 0;
	private PlayerAttribute playerAttribute;
	private BattleSceneMainUIController mainUIController;
	private void Start()
	{
		playerAttribute = Utils.GetPlayerAttribute();
		mainUIController = Utils.GetMainUIController();
	}
	private void Update()
	{
		// test01();
	}

	private void test01()
	{
		if (countNum < 10000)
		{
			countNum++;
			playerAttribute.PlayerPoints = countNum;
			mainUIController.UpdatePlayerPointCounterUI();
		}
	}

}
