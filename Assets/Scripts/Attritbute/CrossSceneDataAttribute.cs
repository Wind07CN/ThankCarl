using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSceneDataAttribute
{
	// charactor Num 
	public int CharactorNum { get; set; }

	// charactor Permanent Buff Level
	public int PlayerMaxHealthLevel { get; set; }

	// State of Player Skill Unlock
	public List<bool> SkillsUnlockSituation { get; set; }

/*	public Dictionary<string, bool> SkillsUnlockStateDic = 
		new Dictionary<string, bool>
		{
			{nameof(FireBall), false }
		};*/
}
