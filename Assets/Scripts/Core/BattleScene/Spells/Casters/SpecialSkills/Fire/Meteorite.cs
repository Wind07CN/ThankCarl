using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : AbstractSpellCaster
{
	[SerializeField] private GameObject meterorite;

	public override void Cast(ISpell spell)
	{
		Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		Instantiate(meterorite, mousePos, Quaternion.identity);
	}
}
