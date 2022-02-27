using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConjureTable : MonoBehaviour
{

	private PlayerSkillController playerSkillController;
	public GameObject PrimaryHolder;
	public GameObject SecondaryHolder;
	public GameObject FirePrefab;
	public GameObject WaterPrefab;
	public GameObject EarthPrefab;
	public GameObject AirPrefab;

	private bool shouldUpdateUI = false;

	private void Start()
	{
		playerSkillController = GameObject.Find("Player").GetComponent<PlayerSkillController>();
	}

	private void Update()
	{
		if (shouldUpdateUI)
		{
			UpdateUI();
		}
	}


	public void UpdateConjureTableUI()
	{
		shouldUpdateUI = true;
	}

	private void UpdateUI()
	{
		ClearPreviousUI();
		bool isFirstElement = true;
		GameObject newElement;

		foreach (ElementType element in playerSkillController.GetConjuredElements())
		{
			switch (element)
			{
				case ElementType.Fire:
					newElement = FirePrefab;
					break;
				case ElementType.Water:
					newElement = WaterPrefab;
					break;
				case ElementType.Earth:
					newElement = EarthPrefab;
					break;
				case ElementType.Air:
					newElement = AirPrefab;
					break;
				default:
					throw new System.Exception("Unknown ElementType");
			}

			if (true == isFirstElement)
			{
				Instantiate(newElement, PrimaryHolder.transform);
				isFirstElement = false;
			}
			else
			{
				Instantiate(newElement, SecondaryHolder.transform);
			}
		}
		shouldUpdateUI = false;
	}

	private void ClearPreviousUI()
	{
		foreach (Transform child in PrimaryHolder.transform)
		{
			Destroy(child.gameObject);
		}
		foreach (Transform child in SecondaryHolder.transform)
		{
			Destroy(child.gameObject);
		}
	}

}
