using UnityEngine;

public class Whirl : AbstractSpellCaster
{
    public GameObject WhirlPrefab;
    
    public override void Cast(SpellAttribute spellAttribute)
    {
        Debug.Log("Whirl");
    }

}