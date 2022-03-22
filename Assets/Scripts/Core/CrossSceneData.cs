using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSceneData : MonoBehaviour
{
    public int currentCharactorNum = 0;

    public int currentGold = 0;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
