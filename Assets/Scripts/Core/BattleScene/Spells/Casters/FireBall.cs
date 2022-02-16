using UnityEngine;

public class FireBall : AbstractSpellCaster
{
    public GameObject FireBallPrefab;
    
    public override void Cast(SpellAttribute spellAttribute)
    {
        Debug.Log("FireBall"); 
    }
}