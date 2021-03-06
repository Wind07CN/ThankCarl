using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phoenix : AbstractSpellCaster
{
	private GameObject playerGameobj;
	[SerializeField] private GameObject phoenixPrefab;

	private void Start()
	{
		playerGameobj = Utils.GetPlayerObject();
	}

	public override void Cast(ISpell spell)
	{
		GameObject gameObject = Instantiate(phoenixPrefab, playerGameobj.transform.position, Quaternion.identity);
		gameObject.transform.eulerAngles = new Vector3(0, 0, playerGameobj.GetComponent<PlayerMoveController>().GetMouseAngle());
	}
}
