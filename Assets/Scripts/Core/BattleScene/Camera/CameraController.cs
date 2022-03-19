using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float cameraHeight = -20f;
    public Vector3 Velocity = Vector3.zero;
    public float SmoothTime = 0.15f;

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + Vector3.forward * cameraHeight;
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, SmoothTime);
        }
    }


}
