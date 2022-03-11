using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{

	/// <summary>
	/// Get playerAttribute
	/// </summary>
	/// <returns></returns>
	public static PlayerAttribute GetPlayerAttribute()
	{
		return GameObject.FindGameObjectWithTag(Constants.PlayerTag).GetComponent<PlayerController>().playerAttribute;
	}

	/// <summary>
	/// Get MainUI Component
	/// </summary>
	/// <returns></returns>
	public static BattleSceneMainUIController GetMainUIController()
	{
		return GameObject.FindGameObjectWithTag(Constants.MainUITag).GetComponent<BattleSceneMainUIController>();
	}

	/// <summary>
	/// Get BattSceneController Component
	/// </summary>
	/// <returns></returns>
	public static BattleSceneController GetMainController()
	{
		return GameObject.FindGameObjectWithTag(Constants.MainController).GetComponent<BattleSceneController>();
	}


	public static GameObject GetPlayerObject()
	{
		return GameObject.FindGameObjectWithTag(Constants.PlayerTag);
	}

	/// <summary>
	/// Find THE Nearest Enemy to the Target
	/// </summary>
	/// <param name="enemiesPos"></param>
	/// <param name="startPos"></param>
	/// <param name="maxDistance"></param>
	/// <returns></returns>
	public static int FindTheNearestEnemy(List<GameObject> enemiesPos, GameObject startPos, float maxDistance)
	{
		int nearestEnemyPosInArray = -1;
		float minDistance = Vector3.Distance(enemiesPos[0].transform.position, startPos.transform.position);

		if (minDistance <= maxDistance)
		{
			nearestEnemyPosInArray = 0;
		}

		for (int i = 1; i < enemiesPos.Count; i++)
		{
			float nextDistance = Vector3.Distance(enemiesPos[i].transform.position, startPos.transform.position);
			if (nextDistance <= maxDistance && nextDistance < minDistance)
			{
				nearestEnemyPosInArray = i;
				minDistance = nextDistance;
			}
		}

		return nearestEnemyPosInArray;
	}

	public static int CalculateGold(int level)
	{
		if (level <= 0)
		{
			return 0;
		}
		return level * 10 + 20;
	}
}
