using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAttribute
{

	public Dictionary<ElementType, string> ElementImg { get; private set; }

	public List<ElementType> CurrentEleList { set; get; }

	public int MaxElement { get; set; } = 3;

	public enum ElementType
	{
		Fire,
		Water,
		Soil,
		Wind,
		Unknow, 
	};

	public ElementAttribute(int maxElement) {
		InitDict();
		MaxElement = maxElement - 1;
		CurrentEleList = new List<ElementType>();
	}

	// 将所有元素对应的图片和元素联系一起，便于后期修改, **感觉可以不要
	private void InitDict() {
		ElementImg = new Dictionary<ElementType, string>
		{
			{ ElementType.Fire, "Image1" },
			{ ElementType.Water, "Image2" },
			{ ElementType.Wind, "Image3" },
			{ ElementType.Soil, "Image4" },
			{ ElementType.Unknow, "Image5" }
		};
	}

	// 获取元素相应的图片
	public string GetElementImg(ElementType elementType) {
		return ElementImg[elementType];
	}


	//
	public void SetELeList(ElementType element, int pos) {
		if (pos > MaxElement) return;	// 不允许超过当前的元素上限
		CurrentEleList.Add(element);
	}



	
}
