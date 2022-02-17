using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{

	[SerializeField] private int playerMaxLife = Constants.PlayerDefaultMaxLife;
	[SerializeField] private int playerArmour = Constants.PlayerDefaultArmour;
	[SerializeField] private float playerMoveSpeed = Constants.PlayerDefaultMoveSpeed;

	[HideInInspector] public PlayerController playerController;
	[HideInInspector] public PlayerAttribute playerAttribute;

	private GameObject mainCameraObject;

	private void Awake()
	{
		InitScene();
	}

	private void Update()
	{
		if (!playerAttribute.IsAlive && playerAttribute.IsActive)
		{
			playerController.KillPlayer();
		}
	}

	private void InitScene()
	{
		InitPlayer();
		InitMainCamera();
		InitUI();

		InitSkillSys();
		
	}

	private void InitPlayer()
	{
		playerAttribute = new PlayerAttribute(playerMaxLife, playerMoveSpeed, playerArmour);

		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerController.InitPlayer(playerAttribute);
	}

	private void InitMainCamera()
	{
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCameraController>().InitCamera(playerAttribute);
	}

	private void InitUI()
	{
		GameObject.FindGameObjectWithTag("MainUI").GetComponent<BattleSceneMainUIController>().InitMainUI(playerAttribute);
	}

	private void InitSkillSys() {
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSkillController>().InitPlayerSkillSys(playerAttribute);
	}


}
