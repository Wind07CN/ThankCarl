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

}
