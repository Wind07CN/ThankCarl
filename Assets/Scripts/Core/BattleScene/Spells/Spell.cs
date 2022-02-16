using System.Collections.Generic;
using UnityEngine;

public class Spell<T>: ISpell where T : ISpellCaster
{
    private SpellAttribute attribute;

    public Spell(params ElementType[] elementsCombination)
    {
        if (elementsCombination.Length > 0)
        {
            this.attribute = new SpellAttribute(elementsCombination);
        }
    }

    public List<ElementType> GetElementsCombination()
    {
        return attribute.ElementsCombination;
    }

    public ISpellCaster FindCasterComponent()
    {
        return GameObject.Find("SpellCaster").GetComponent<T>();
    }

    public SpellAttribute GetSpellAttribute()
    {
        return attribute;
    }

    public void SetSpellAttribute(SpellAttribute attribute)
    {
        this.attribute = attribute;
    }
}