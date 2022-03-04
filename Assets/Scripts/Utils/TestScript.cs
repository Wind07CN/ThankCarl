using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

	private int countNum = 0;

	public GameObject chainPrefab;
	public Transform player;

	private void Start()
	{
		// playerAttribute = Utils.GetPlayerAttribute();
		// mainUIController = Utils.GetMainUIController();
		// for (double i = 100000; i > 0; i--) { }
		// player1 = GameObject.FindGameObjectWithTag("Player");
	}
	private void Update()
	{
		// test01();
		test02();
	}

	private void test02()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(chainPrefab, player);
		}
	}
}
