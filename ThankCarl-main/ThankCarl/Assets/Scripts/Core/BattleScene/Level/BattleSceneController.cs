using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneController : MonoBehaviour
{

	[SerializeField] private int playerMaxLife = Constants.PlayerDefaultMaxLife;
	[SerializeField] private int playerArmour = Constants.PlayerDefaultArmour;
	[SerializeField] private float playerMoveSpeed = Constants.PlayerDefaultMoveSpeed;

	[HideInInspector] public PlayerController playerController;
	[HideInInspector] public PlayerAttribute player;

	private GameObject mainCameraObject;
	// [SerializeField] 

	private void Awake()
	{
		InitScene();
	}

	private void Update()
	{
		if (!player.IsAlive && player.IsActive)
		{
			playerController.KillPlayer();
		}
	}

	private void InitScene()
	{
		player = new PlayerAttribute(playerMaxLife, playerMoveSpeed, playerArmour);
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerController.InitPlayer(player);

		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MainCameraController>().InitCamera(player);
	}



}
