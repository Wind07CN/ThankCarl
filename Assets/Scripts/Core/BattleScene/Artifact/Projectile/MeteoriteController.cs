using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
	[SerializeField] private GameObject scorchZonePrefab;
	[SerializeField] private float fallHeight = 100;
	[SerializeField] private float fallTime = 1;
	private float fallSpeed;

	private void Awake()
	{
		fallSpeed = fallHeight / fallTime;
		transform.position += fallHeight * new Vector3(-1, 1, 0); 
	}

	private void Update()
	{
		if (fallTime > 0)
		{
			fallHeight -= Time.deltaTime;
			transform.position += fallSpeed * Time.deltaTime * new Vector3(-1, 1, 0);
		}
	}
}
