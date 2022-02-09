using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float playerDefaultSpeed = 20;
	public float playerSpeedRate = 1;

	public void Start()
	{

	}

	private void Update()
	{
		KeyBoardInput();

	}



	private void KeyBoardInput() 
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector2.up * Time.deltaTime * playerDefaultSpeed * playerSpeedRate);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(-Vector2.up * Time.deltaTime * playerDefaultSpeed * playerSpeedRate);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector2.left * Time.deltaTime * playerDefaultSpeed * playerSpeedRate);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector2.right * Time.deltaTime * playerDefaultSpeed * playerSpeedRate);
		}
	}

}
