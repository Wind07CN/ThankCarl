using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffectManager : MonoBehaviour
{
	[SerializeField] private GameObject fireExplosion;
	[SerializeField] private GameObject WaterExplosion;
	[SerializeField] private GameObject SoilExplosion;
	[SerializeField] private GameObject windSprite;


	public void InitCollisionEffect(ElementType elementType, Vector3 position)
	{
		GameObject sprite;
		switch (elementType)
		{
			case ElementType.Fire:
				sprite = fireExplosion;
				break;
			case ElementType.Water:
				sprite = WaterExplosion;
				break;
			case ElementType.Soil:
				sprite = SoilExplosion;
				break;
			case ElementType.Wind:
				sprite = windSprite;
				break;
			default:
				sprite = null;
				break;
		}

		Instantiate(sprite, position, Quaternion.identity);
	}
}
