using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{

	[HideInInspector] public PlayerAttribute playerAttribute;

	private bool isPlayerDead = false;

	private GameObject mainCameraObject;

	private void Awake()
	{
		InitScene();
	}

	private void Update()
	{
		if (isPlayerDead)
		{
			SwitchSence();
		}
	}

	private void InitScene()
	{
		Debug.Log("InitScene");
	}


	public void PlayerIsKilled()
	{
		isPlayerDead = true;
		Debug.Log("Player is dead");

	}

	private void SwitchSence()
	{
		Debug.Log("ChangeSence");
	}


}
