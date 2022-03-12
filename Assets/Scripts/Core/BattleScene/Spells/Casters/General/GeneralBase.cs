using UnityEngine;

public class GeneralBase : AbstractSpellCaster
{
    
    public override void Cast(ISpell spell)
    {
        Debug.Log("General"); 
    }
}