using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmeraController : MonoBehaviour
{
	[SerializeField] private Transform player;

	[SerializeField] private float cameraHeight = -20f;
	public Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.1f;

	private void LateUpdate()
	{
		if (player != null)
		{
			Vector3 targetPosition = player.position + Vector3.forward * cameraHeight;
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		}
	}


}
