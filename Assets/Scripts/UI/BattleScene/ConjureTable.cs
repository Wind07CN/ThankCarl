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
	[SerializeField] private Sprite defautSprite;

	[SerializeField] private int DefaultElementCount = 2;

	[SerializeField] private GameObject emptyPrefab;

	private List<Image> images = new List<Image>();

	private Dictionary<ElementType, Sprite> spritesDic = new Dictionary<ElementType, Sprite>();


	private void Start()
	{
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
		spritesDic.Add(ElementType.None, defautSprite);
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
		images[pos - 1].sprite = spritesDic[elementType];
	}

	public void ClearElement()
	{
		foreach (Image image in images)
		{
			image.sprite = defautSprite;
		}
	}

}
