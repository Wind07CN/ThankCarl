﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
	private Image image;
	private PlayerAttribute mPlayer;
	[HideInInspector] public bool shouldUpdate = false;

	private void Start()
	{
		image = GetComponent<Image>();
		mPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerAttribute;
	}

	private void Update()
	{
		if (shouldUpdate)
		{
			image.fillAmount = (float)mPlayer.CurrentLife / (float)mPlayer.MaxLife;
			shouldUpdate = false;
		}
	}
}
