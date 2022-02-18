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

	public static BattleSceneMainUIController GetMainUIController()
	{
		return GameObject.FindGameObjectWithTag("MainUI").GetComponent<BattleSceneMainUIController>();
	}

}
