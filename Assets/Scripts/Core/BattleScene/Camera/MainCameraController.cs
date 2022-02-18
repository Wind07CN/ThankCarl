using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 主要负责移动, 然后作为玩家的父级带动玩家移动
public class MainCameraController : MonoBehaviour
{
	// [SerializeField]
	private PlayerAttribute mPlayerAttribute;

	[SerializeField] private float cameraPositionZ = -10f;

	private void Start()
	{
		transform.position = new Vector3(0, 0, cameraPositionZ);
		mPlayerAttribute = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerAttribute;
	}

	private void Update()
	{
		if (mPlayerAttribute.IsActive)
		{
			HandleKeyBoardInput();
		}
	}

	public void InitCamera(PlayerAttribute player)
	{
		mPlayerAttribute = player;
	}


	private void HandleKeyBoardInput()
	{
		float moveDistance = Time.deltaTime * mPlayerAttribute.MoveSpeed;

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


	/// <summary>
	/// Change the High of Camera
	/// </summary>
	/// <param name="high"></param>
	private void ChangeCameraHigh(float high)
	{
		Vector3 currentPos = transform.position;
		transform.position = new Vector3(currentPos.x, currentPos.y, high);
	}
}
