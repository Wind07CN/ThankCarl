using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
	public GameObject PointTextObj;
	public GameObject BarImageObj;
	private PlayerAttribute playerAttribute;
	[HideInInspector] public bool shouldUpdate = true;

	private void Start()
	{
		playerAttribute = GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerAttribute;
	}

	private void Update()
	{
		if (shouldUpdate)
		{
			UpdateBarLength();
			UpdatePointText();
			shouldUpdate = false;
		}
	}

	private void UpdatePointText()
	{
		Text pointText = PointTextObj.GetComponent<Text>();
		pointText.text = (int) playerAttribute.CurrentMana + "/" + (int) playerAttribute.MaxMana;
	}

	private void UpdateBarLength()
	{
		Image image = BarImageObj.GetComponent<Image>();
		image.fillAmount = playerAttribute.CurrentMana / playerAttribute.MaxMana;
	}
}
