using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 主要负责移动, 然后作为玩家的父级带动玩家移动
public class MainCameraController : MonoBehaviour
{
	// [SerializeField]
	private PlayerAttribute mPlayer;
	
	[SerializeField] private float cameraPositionZ = -10f;

	private void Start()
	{
	}

	private void Update()
	{
		// 这里是检测玩家的是否激活的情况, 而不是存活, 游戏开始的倒计时玩家也不能操作
		if (mPlayer.IsActive)
		{
			HandleKeyBoardInput();
		}
	}

	public void InitCamera(PlayerAttribute player)
	{
		mPlayer = player;
	}


	private void HandleKeyBoardInput()
	{
		float moveDistance = Time.deltaTime * mPlayer.MoveSpeed;

		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector2.up * moveDistance);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector2.down * moveDistance);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector2.left * moveDistance);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector2.right * moveDistance);
		}
	}


	// **************
	private void ChangeCameraHigh(float high)
	{
		Vector3 currentPos = transform.position;
		transform.position = new Vector3(currentPos.x, currentPos.y, high);
	}
}
