using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
	private void Start()
	{
		this.GetComponent<Image>().fillAmount = 0.5f;
	}
}
