using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ElementUI : MonoBehaviour
{
	public GameObject element1;
	public GameObject element2;
	public GameObject element3;
	public GameObject element4;
	public GameObject element5;
	private ElementAttribute element;

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;

	public int maxElement = 3;
	// 现在玩家输入的位置
	private int currentElePos = 0;

	private List<GameObject> elementsUI;

	private void Start()
	{
		element = new ElementAttribute(maxElement);
		elementsUI = new List<GameObject>() {
			element1 ,
			element2 ,
			element3 ,
			element4 ,
			element5 ,
		};
	}

	private void Update()
	{
		//GetElemenInput();
		//Debug.Log(element.CurrentEleList);
		UpdateUI();
	}

	private void OnGUI()
	{
		GetElemenInput();
	}

	// 这里可能会被移到专门的GameControl或者放到玩家控制那里里面 暂时放在这里
	private void GetElemenInput()
	{

		Debug.Log(currentElePos);
		if (currentElePos <= maxElement)
		{			
			if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Alpha1.ToString())))
			{
				element.SetELeList(ElementAttribute.ElementType.Fire, currentElePos);
				currentElePos++;
			}
			if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Alpha2.ToString())))
			{
				element.SetELeList(ElementAttribute.ElementType.Wind, currentElePos);
				currentElePos++;
			}
			if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Alpha3.ToString())))
			{
				element.SetELeList(ElementAttribute.ElementType.Soil, currentElePos);
				currentElePos++;
			}
			if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Alpha4.ToString())))
			{
				element.SetELeList(ElementAttribute.ElementType.Water, currentElePos);
				currentElePos++;
			}
		}
		
		if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())))
		{
			element.CurrentEleList.Clear();
			currentElePos = 0;
		}
	}


	// 这里可能会被修改
	private void UpdateUI() {
		int temp = 0;
		foreach (ElementAttribute.ElementType ele in element.CurrentEleList) {
			switch (ele)
			{
				case ElementAttribute.ElementType.Fire:
					elementsUI[temp].GetComponent<Image>().sprite = sprite1;
					break;
				case ElementAttribute.ElementType.Wind:
					elementsUI[temp].GetComponent<Image>().sprite = sprite2;
					break;
				case ElementAttribute.ElementType.Soil:
					elementsUI[temp].GetComponent<Image>().sprite = sprite3;
					break;
				case ElementAttribute.ElementType.Water:
					elementsUI[temp].GetComponent<Image>().sprite = sprite4;
					break;
				default:
					break;
			}
			temp++;
		}
		for (; temp < 5; temp++)
		{
			elementsUI[temp].GetComponent<Image>().sprite = sprite5;
		}
	}
	
}
