using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSceneData : MonoBehaviour
{
	public int currentCharactor = 0;

	private void Awake()
	{
		DontDestroyOnLoad(this);
	}
}
