using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveWalls : AbstractSpellCaster
{
    public GameObject wallprefab;
    private GameObject playerGameobj;
    private Transform wall;

    private void Start()
    {
        playerGameobj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {

        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;

        wall = Instantiate(wallprefab, mPos, Quaternion.identity).transform;
        wall.eulerAngles = new Vector3(0, 0, Utils.GetTwoPointsEulerAngle(mPos, playerGameobj.transform.position));
    }
}
