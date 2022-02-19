using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{

	[HideInInspector] public PlayerAttribute playerAttribute;
	public float difficultyMultiplier = 1.0f;


	private GameObject mainCameraObject;



	private void Awake()
	{
		InitScene();
	}

	private void Update()
	{
		if (!playerAttribute.IsAlive)
		{
			SwitchSence();
		}
	}

	

	private void InitScene()
	{
		Debug.Log("InitScene");
	}


	private void SwitchSence()
	{
		Debug.Log("ChangeSence");
	}


}
