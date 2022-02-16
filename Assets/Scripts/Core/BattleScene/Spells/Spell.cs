using System.Collections.Generic;
using UnityEngine;

public class Spell<T>: ISpell where T : ISpellCaster
{
    private SpellAttribute attribute;

    public Spell(params ElementType[] elementsCombination)
    {
        this.attribute = new SpellAttribute(elementsCombination);
    }

    public List<ElementType> GetElementsCombination()
    {
        return attribute.ElementsCombination;
    }

    public ISpellCaster FindCasterComponent()
    {
        Debug.Log(GameObject.Find("SpellCaster"));
        return GameObject.Find("SpellCaster").GetComponent<T>();
    }

    public SpellAttribute GetSpellAttribute()
    {
        return attribute;
    }
}