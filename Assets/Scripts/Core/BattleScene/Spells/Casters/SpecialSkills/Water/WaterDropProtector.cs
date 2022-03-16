using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropProtector : AbstractSpellCaster
{
    [SerializeField] private GameObject waterDropProtector;

    private GameObject playerGameobj;

    private void Start()
    {
        playerGameobj = Utils.GetPlayerObject();

    }

    public override void Cast(ISpell spell)
    {
        Instantiate(waterDropProtector, playerGameobj.transform.position, Quaternion.identity);
    }
}
