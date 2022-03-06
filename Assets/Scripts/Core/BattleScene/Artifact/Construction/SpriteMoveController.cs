
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMoveController : MonoBehaviour
{
	[SerializeField] private float rotateSpeed = 30f;

	private GameObject player;

	private int subSprite = 3;

	private void Awake()
	{
		player = Utils.GetPlayerObject();
	}

	private void Update()
	{
		if (subSprite == 0) 
		{
			Destroy(gameObject);
		}
		transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
	}

	private void LateUpdate()
	{
		transform.position = player.transform.position;
	}

	public void DestroySub() 
	{
		subSprite--;
	}
}
