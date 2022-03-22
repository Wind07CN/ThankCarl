using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSceneData : MonoBehaviour
{
    public int currentCharactorNum = 0;

    public string NextSceneNum = Constants.LevelUpSceneTag;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
