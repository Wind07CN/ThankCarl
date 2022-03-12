using UnityEngine;
public abstract class AbstractSpellCaster: MonoBehaviour, ISpellCaster
{
    public abstract void Cast(ISpell spell);
}