using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineController : MonoBehaviour
{

	private LineRenderer lineRenderer;

	[SerializeField] private Texture[] textures;

	[SerializeField] private float fps = 30f;
	private int animationStep;
	private float fpsCounter;

	[SerializeField] private GameObject player;
	private List<GameObject> enemis;


	[SerializeField] private float maxRange = 5f;
	[SerializeField] private int bounceCount = 4;
	[SerializeField] private float disappearTime = 2f;

	private void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.positionCount = 1;
		player = GameObject.FindGameObjectWithTag("Player");
		animationStep = -1;
		SetDisplay();
	}

	private void Start()
	{


	}

	private void Update()
	{
		lineRenderer.SetPosition(0, player.transform.position);
		UpdateAnimation();
	}

	private void DestroyLine()
	{
		Destroy(gameObject);
	}

	private void UpdateAnimation()
	{
		fpsCounter += Time.deltaTime;

		if (fpsCounter >= 1 / fps)
		{
			animationStep++;
			if (animationStep >= textures.Length)
			{
				animationStep = 0;
			}

			lineRenderer.material.SetTexture("_MainTex", textures[animationStep]);

			fpsCounter = 0;
		}
	}

	private void SetDisplay() {

		lineRenderer.SetPosition(0, player.transform.position);
		enemis = GameObject.FindGameObjectsWithTag("Enemy").ToList();

		if (enemis == null)
		{
			DestroyLine();
		}

		GameObject lastGameObject = player;

		for (int i = 1; i <= bounceCount; i++)
		{
			if (enemis.Count < 1) 
			{
				Debug.Log("Can't Find Next Enemy!");
				break;
			}

			int nextEnemyPosInArray = Utils.FindTheNearestEnemy(enemis, lastGameObject, maxRange);
			
			if (nextEnemyPosInArray == -1)
			{
				Debug.Log("Can't Find Next in range");

				break;

			}
			else
			{
				lineRenderer.positionCount++;
				lineRenderer.SetPosition(i, enemis[nextEnemyPosInArray].transform.position);
				lastGameObject = enemis[nextEnemyPosInArray];

				// Stun Enemy
				enemis[nextEnemyPosInArray].GetComponent<EnemyController>().StunEnemy(4f);

				enemis.RemoveAt(nextEnemyPosInArray);

			}
		}

		Invoke(nameof(DestroyLine), disappearTime);
	}

}
