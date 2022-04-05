using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlast : AbstractSpellCaster
{
	[SerializeField] private GameObject laserPrefab;

	public override void Cast(ISpell spell)
	{
		Vector3 pos = transform.position;
		pos.z = 0.5f;
		Instantiate(laserPrefab, pos, Quaternion.identity);
	}
}
