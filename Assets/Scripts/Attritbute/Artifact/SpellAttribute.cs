using System;
using System.Collections.Generic;
public class SpellAttribute
{
    public ElementType Type { get; }

    // the name that can be used with GameObject.Find
    public List<ElementType> ElementsCombination;


    public SpellAttribute(params ElementType[] elementsCombination)
    {
        if (elementsCombination.Length == 0)
        {
            throw new System.Exception("Spell must have at least one element");
        }
        this.Type = elementsCombination[0];
        this.ElementsCombination = new List<ElementType>(elementsCombination);
    }
}