using System.Collections.Generic;
using UnityEngine;

public class Spell<T> : ISpell where T : ISpellCaster
{
    private SpellAttribute attribute;

    public Spell(float cost, params ElementType[] elementsCombination)
    {
        if (elementsCombination.Length > 0)
        {
            this.attribute = new SpellAttribute(cost, elementsCombination);
        }
        else
        {
            throw new System.Exception("Spell must have at least one element");
        }
    }

    public List<ElementType> GetElementsCombination()
    {
        return attribute.ElementsCombination;
    }

    public ISpellCaster FindCasterComponent()
    {
        T component = Utils.GetSpellCasterObject().GetComponent<T>();
        if (component == null)
        {
            throw new System.Exception("Spell component not found. Did you forget to attach the spell script to the game object?");
        }
        return component;
    }

    public SpellAttribute GetSpellAttribute()
    {
        return attribute;
    }

    public void SetSpellAttribute(SpellAttribute attribute)
    {
        this.attribute = attribute;
    }

    public ElementType GetPrincipalElementType()
    {
        return attribute.PrincipleType;
    }

    public float GetManaCost()
    {
        return attribute.ManaCost;
    }

    public string GetSpellName()
    {
        return this.GetType().Name;
    }

}