using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : AbstractSpellCaster
{
	[SerializeField] private GameObject CannonTowerPrefab;
	private HitEffectGenerator hitEffectGenerator;

	private void Start()
	{
		hitEffectGenerator = Utils.GetMainController().GetComponent<HitEffectGenerator>();
	}

	public override void Cast(ISpell spell)
	{
		Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mPos.z = 0;
		hitEffectGenerator.InitHitEffect(ElementType.Earth, mPos);
		Instantiate(CannonTowerPrefab, mPos, Quaternion.identity);
	}
}
