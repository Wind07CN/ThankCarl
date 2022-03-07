using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConjureTable : MonoBehaviour
{

	private PlayerSkillController playerSkillController;
	[SerializeField] private GameObject PrimaryHolder;
	[SerializeField] private GameObject SecondaryHolder;

	[SerializeField] private Sprite fire;
	[SerializeField] private Sprite water;
	[SerializeField] private Sprite wind;
	[SerializeField] private Sprite soil;
	[SerializeField] private Sprite none;
	[SerializeField] private Sprite locked;

	[SerializeField] private GameObject[] elementsIcons;
	private List<Image> images = new List<Image>();

	[SerializeField] private int unlockedSubElementCount = 1;

	[SerializeField] private GameObject emptyPrefab;


	private Dictionary<ElementType, Sprite> spritesDic = new Dictionary<ElementType, Sprite>();


	private void Start()
	{
		// playerSkillController = Utils.GetPlayerObject().GetComponent<PlayerSkillController>();
		playerSkillController = GameObject.Find("Player").GetComponent<PlayerSkillController>();
		InitDic();
		InitConjure();
	}

	private void InitDic()
	{
		spritesDic.Clear();
		spritesDic.Add(ElementType.Fire, fire);
		spritesDic.Add(ElementType.Water, water);
		spritesDic.Add(ElementType.Wind, wind);
		spritesDic.Add(ElementType.Soil, soil);
		spritesDic.Add(ElementType.None, none);
		spritesDic.Add(ElementType.Locked, locked);
	}

	private void InitConjure()
	{
		images.Clear();
		foreach (GameObject element in elementsIcons) 
		{
			images.Add(element.GetComponent<Image>());
		}
		for (int i = 0; i <= unlockedSubElementCount; i++) 
		{
			images[i].sprite = spritesDic[ElementType.None];
		}
	}

	public void UnlockConjure()
	{
		images[++unlockedSubElementCount].sprite = spritesDic[ElementType.None];
	}

	public void UpdateElement(int pos, ElementType elementType)
	{
		// elementType -> sprite
		images[pos - 1].sprite = spritesDic[elementType];
	}

	public void ClearElement()
	{
		for (int i = 0; i <= unlockedSubElementCount; i++) 
		{
			images[i].sprite = spritesDic[ElementType.None];
		}
	}

}
