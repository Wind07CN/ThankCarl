using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

	// private int countNum = 0;

	public GameObject chainPrefab;
	public GameObject FirePrefab;
	public Transform player;
	public GameObject WavePreFab;

	private void Start()
	{
		// playerAttribute = Utils.GetPlayerAttribute();
		// mainUIController = Utils.GetMainUIController();
		// for (double i = 100000; i > 0; i--) { }
		player = GameObject.FindGameObjectWithTag("Player").transform;
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
			// Instantiate(chainPrefab, player);

			//GameObject gameObject = Instantiate(FirePrefab, player.transform.position, Quaternion.identity);
			//gameObject.transform.eulerAngles = new Vector3(0, 0, player.gameObject.GetComponent<PlayerMoveController>().GetMouseAngle());

			Instantiate(WavePreFab, player.position, Quaternion.identity);
		}
		if (Input.GetKeyUp(KeyCode.V))
		{

			

		}
	}
}
