using System;
using System.Collections.Generic;
public class SpellAttribute
{
    public ElementType PrincipleType { get; private set; }

    public List<ElementType> ElementsCombination;

    public float ManaCost { get; private set; }


    public SpellAttribute(float ManaCost, params ElementType[] elementsCombination)
    {
        if (elementsCombination.Length == 0)
        {
            throw new System.Exception("Spell must have at least one element");
        }
        this.PrincipleType = elementsCombination[0];
        this.ElementsCombination = new List<ElementType>(elementsCombination);
        this.ManaCost = ManaCost;
    }

    public SpellAttribute(float ManaCost, bool isGeneral, params ElementType[] elementsCombination)
    {
        if (elementsCombination.Length == 0)
        {
            throw new System.Exception("Spell must have at least one element");
        }
        this.PrincipleType = elementsCombination[0];
        this.ElementsCombination = new List<ElementType>(elementsCombination);
        this.ManaCost = ManaCost;
    }
}