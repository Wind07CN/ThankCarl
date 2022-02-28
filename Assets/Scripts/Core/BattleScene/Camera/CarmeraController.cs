using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmeraController : MonoBehaviour
{
	[SerializeField] private Transform player;

	[SerializeField] private float cameraHeight = -20f;

	private void LateUpdate()
	{
		if (player != null)
		{
			transform.position = player.position + Vector3.forward * cameraHeight;
		}
	}


}
