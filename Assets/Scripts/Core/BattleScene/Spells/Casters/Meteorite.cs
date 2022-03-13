using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : AbstractSpellCaster
{
	[SerializeField] private MeteoriteController meterorite;
	private GameObject playerGameobj;

	[SerializeField] private int explosionDamage = 100;
	[SerializeField] private int scorchDamage = 15;
	[SerializeField] private float explosionRange = 1f;
	[SerializeField] private bool hasForce = true;
	[SerializeField] private float forceFactor = 30f;

	private void Start()
	{
		playerGameobj = Utils.GetPlayerObject();
		meterorite.InitMetreorite(explosionDamage, scorchDamage, explosionRange, hasForce, forceFactor);
	}

	public override void Cast(ISpell spell)
	{
		Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		Instantiate(meterorite, mousePos, Quaternion.identity);
	}
}
