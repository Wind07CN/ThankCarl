using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffectController : MonoBehaviour
{
	[SerializeField] private float lastTime = 1f;
	[SerializeField] private float disappearTime = 1f;
	private bool disappearing = false;
	private void Start()
	{
		Invoke(nameof(Disappear), lastTime);
	}

	private void Update()
	{
		if (disappearing)
		{
			if (transform.localScale.x <= 0)
			{
				Destroy(gameObject);
			}
			else
			{
				transform.localScale = transform.localScale - new Vector3(1, 1, 0) * Time.deltaTime / disappearTime;
			}
		}
	}

	private void Disappear() 
	{
		disappearing = true;
	}
}
