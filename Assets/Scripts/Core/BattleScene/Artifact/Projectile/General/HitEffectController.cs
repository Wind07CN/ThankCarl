using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectController : MonoBehaviour
{
	[SerializeField] private float lastTime = 0.3f;
	[SerializeField] private float disappearTime = 0.2f;
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
