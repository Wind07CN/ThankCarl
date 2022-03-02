using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
	private Image image;
	private PlayerAttribute mPlayer;
	[HideInInspector] public bool shouldUpdate = false;
	private void Start()
	{
		image = GetComponent<Image>();
		image.fillAmount = 1.0f;
		mPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerAttribute;
	}

	private void Update()
	{
		if (shouldUpdate)
		{
			image.fillAmount = mPlayer.CurrentMana / mPlayer.MaxMana;
			shouldUpdate = false;
		}
	}

	/// <summary>
	/// if Player life Change Update
	/// 最好还是放在主控这个方法?
	/// </summary>
	public void UpdateManaBar()
	{
		shouldUpdate = true;
	}
}
