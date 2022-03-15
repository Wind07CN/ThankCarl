using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : AbstractSpellCaster
{

    public GameObject FanAeraAttackPrefab;
    private GameObject playerGameobj;
    private Transform fanAera;

    private void Start()
    {
        playerGameobj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {
        fanAera = Instantiate(FanAeraAttackPrefab, playerGameobj.transform.position, Quaternion.identity).transform;
        fanAera.eulerAngles = new Vector3(0, 0, playerGameobj.GetComponent<PlayerMoveController>().GetMouseAngle());
        playerGameobj.GetComponent<PlayerController>().QuickDash(20, 0.2f);
    }
}
