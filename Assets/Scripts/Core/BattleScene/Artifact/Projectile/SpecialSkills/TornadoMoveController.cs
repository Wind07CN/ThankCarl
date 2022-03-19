using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoMoveController : MonoBehaviour
{
	private Vector3 direction;
	[SerializeField] private float moveSpeed = 5f;

	private void Start()
	{
		InitRandomDirection();
	}

	private void Update()
	{
		transform.position += moveSpeed * Time.deltaTime * direction;
	}

	private void InitRandomDirection()
	{
		float angle = Random.Range(0, 360);
		direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0).normalized;
	}

}
