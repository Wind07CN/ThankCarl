using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyImage : MonoBehaviour
{
	public void DestroyGameObj() 
	{
		Destroy(gameObject);
	}

	public void SetPlayerActive() 
	{
		Utils.GetPlayerObject().GetComponent<PlayerController>().SetPlayerActive();
	}
}
