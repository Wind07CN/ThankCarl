using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{

	private ControllerContext controllerContext;
	private PlayerAttribute playerAttribute;
	private GameObject mainCameraObject;

	private void Start()
	{
		controllerContext = ControllerContext.GetContext();
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
		playerAttribute = controllerContext.PlayerController.playerAttribute;
		mainCameraObject = controllerContext.MainCameraController.transform.gameObject;
		Debug.Log("InitScene");
	}

	private void SwitchSence()
	{
		Debug.Log("ChangeSence");
	}


}
