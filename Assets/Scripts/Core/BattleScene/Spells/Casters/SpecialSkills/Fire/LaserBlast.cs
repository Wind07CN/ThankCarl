using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlast : AbstractSpellCaster
{
	[SerializeField] private GameObject laserPrefab;

	public override void Cast(ISpell spell)
	{
		Instantiate(laserPrefab, transform.position, Quaternion.identity);
	}
}
