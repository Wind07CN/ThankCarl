using UnityEngine;

public class Whirl : AbstractSpellCaster
{
    public GameObject WhirlPrefab;
    private GameObject playerGameObj;

    private void Start()
    {
        playerGameObj = Utils.GetPlayerObject();
    }
    
    public override void Cast(SpellAttribute spellAttribute)
    {
        Instantiate(WhirlPrefab, playerGameObj.transform.position, Quaternion.identity);
    }


}