using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConjureTable : MonoBehaviour
{

	private PlayerSkillController playerSkillController;
	[SerializeField] private GameObject PrimaryHolder;
	[SerializeField] private GameObject SecondaryHolder;

	[SerializeField] private Sprite DefautSprite;

	[SerializeField] private int DefaultElementCount = 2;

	[SerializeField] private GameObject emptyPrefab;

	private List<Image> images = new List<Image>();


	private void Start()
	{
		playerSkillController = GameObject.Find("Player").GetComponent<PlayerSkillController>();
		InitConjure();
	}

	private void InitConjure()
	{
		images.Clear();
		images.Add(Instantiate(emptyPrefab, PrimaryHolder.transform).GetComponent<Image>());
		for (int i = 0; i < DefaultElementCount - 1; i++)
		{
			images.Add(Instantiate(emptyPrefab, SecondaryHolder.transform).GetComponent<Image>());
		}
	}

	public void AddConjure()
	{
		images.Add(Instantiate(emptyPrefab, SecondaryHolder.transform).GetComponent<Image>());
	}

	public void UpadateElement(int pos, ElementType elementType)
	{
		// elementType -> sprite
		images[pos].sprite = DefautSprite;
	}

	public void ClearElement()
	{
		foreach (Image image in images)
		{
			image.sprite = DefautSprite;
		}
	}

}
