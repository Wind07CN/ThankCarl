using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStone : AbstractSpellCaster
{
    [SerializeField] private GameObject RollingStonePrefab;
    private GameObject playerGameobj;

    private void Start()
    {
        playerGameobj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {
        Instantiate(RollingStonePrefab, playerGameobj.transform.position, Quaternion.identity);
    }
}
