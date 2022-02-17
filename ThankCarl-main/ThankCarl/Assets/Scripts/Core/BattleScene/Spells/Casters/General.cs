using UnityEngine;

public class General : AbstractSpellCaster
{
    
    public override void Cast(SpellAttribute spellAttribute)
    {
        Debug.Log("General"); 
    }
}