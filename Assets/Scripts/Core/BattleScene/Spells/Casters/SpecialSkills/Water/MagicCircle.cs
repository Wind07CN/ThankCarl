using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : AbstractSpellCaster
{
    public GameObject magicCiclePrefab;
    private GameObject playerGameobj;

    private void Start()
    {
        playerGameobj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {
        Instantiate(magicCiclePrefab, playerGameobj.transform.position, Quaternion.identity);
    }
}
