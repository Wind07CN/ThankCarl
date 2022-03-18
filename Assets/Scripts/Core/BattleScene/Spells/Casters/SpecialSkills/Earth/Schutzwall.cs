using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schutzwall : AbstractSpellCaster
{
    [SerializeField] private GameObject schutzwallPrefab;
    private GameObject playerGameobj;

    private void Start()
    {
        playerGameobj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {
        Instantiate(schutzwallPrefab, playerGameobj.transform.position, Quaternion.identity);
    }
}
