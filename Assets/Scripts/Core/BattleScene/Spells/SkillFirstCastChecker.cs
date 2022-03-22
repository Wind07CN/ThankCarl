using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFirstCastChecker : MonoBehaviour
{
	private void Start()
	{
        PlayerPrefs.DeleteAll();
	}
	[SerializeField] private List<int> registeredSkillNum = new List<int> ();
    public void CheckSpell(int num)
    {
        if (registeredSkillNum.Contains(num)) 
        {
            return;
        }

        registeredSkillNum.Add(num);

        if (PlayerPrefs.GetInt("Skill" + num) != 1)
        {
            PlayerPrefs.SetInt("Skill" + num, 1);
            PlayerPrefs.SetInt(Constants.LearnSkillNum, PlayerPrefs.GetInt(Constants.LearnSkillNum));
            Utils.GetMainUIController().ShowGetNewSkillUI();
        }
    }
}
