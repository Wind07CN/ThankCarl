using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class EnemySpawnController : MonoBehaviour
{
	[SerializeField] private GameObject[] normalEnemyPrefabs;
	[SerializeField] private GameObject[] eliteEnemyPrefabs;
	private int normalEnemyTypeNum;
	private int eliteEnemyTypeNum;

	[SerializeField] private float eliteRate = Constants.EliteDefaultRate;
	[SerializeField] private float battlefieldMaxX = Constants.BattlefieldDefaultMaxX;
	[SerializeField] private float battlefieldMinX = Constants.BattlefieldDefaultMinX;
	[SerializeField] private float battlefieldMaxY = Constants.BattlefieldDefaultMaxY;
	[SerializeField] private float battlefieldMinY = Constants.BattlefieldDefaultMinY;

	private bool needSpawn = true;
	[SerializeField] private float nextSpawnTime = Constants.nextDefaultSpawnTime;

	private PlayerAttribute player;

	private void Start()
	{
		normalEnemyTypeNum = normalEnemyPrefabs.Length;
		eliteEnemyTypeNum = eliteEnemyPrefabs.Length;
		player = Utils.GetPlayerAttribute();
	}

	private void Update()
	{
		if (needSpawn && player.IsActive)
		{
			needSpawn = false;
			Invoke(nameof(SpawnNewEnemy), nextSpawnTime);
		}
	}

	private void UpdateEltieRate(float rate)
	{
		eliteRate = rate;
	}

	private void SpawnNewEnemy()
	{

		Vector2 vector2 = new Vector2(Random.Range(battlefieldMinX, battlefieldMaxX), Random.Range(battlefieldMinY, battlefieldMaxY));
		if (Random.Range(0f, 1f) < eliteRate)
		{
			Instantiate(eliteEnemyPrefabs[Random.Range(0, eliteEnemyTypeNum)], vector2, Quaternion.identity);
		}
		else
		{
			Instantiate(normalEnemyPrefabs[Random.Range(0, normalEnemyTypeNum )], vector2, Quaternion.identity);
		}

		needSpawn = true;
	}
}
