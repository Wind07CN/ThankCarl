using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlastController : MonoBehaviour
{
	public int damage = 200;
	public float disappearTime = 0.3f;
	private bool isDisappear = false;
	private float disappearSpeed;
	private LineRenderer lineRenderer;

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		disappearSpeed = 1 / disappearTime;
		StartCoroutine(LaserShoot());
	}

	private void Update()
	{
		if (isDisappear && disappearTime > 0)
		{
			lineRenderer.widthMultiplier = disappearTime * disappearSpeed; ;
			disappearTime -= Time.deltaTime;
		}
		if (disappearTime <= 0)
		{
			Destroy(gameObject);
		}
	}

	IEnumerator LaserShoot()
	{
		Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

		RaycastHit2D[] hitObjects = Physics2D.RaycastAll(transform.position, direction);


		lineRenderer.SetPosition(0, Vector3.zero);
		lineRenderer.SetPosition(1, position: Vector3.zero + (Vector3)direction * 100);
		lineRenderer.enabled = true;

		foreach (RaycastHit2D hitObject in hitObjects)
		{
			if (hitObject.transform.CompareTag("Enemy"))
			{
				hitObject.transform.GetComponent<EnemyController>().DamageEnemy(damage);
			}
		}

		yield return new WaitForSeconds(disappearTime);
		isDisappear = true;
	}
}