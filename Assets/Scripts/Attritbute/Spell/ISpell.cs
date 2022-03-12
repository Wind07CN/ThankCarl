using System.Collections.Generic;

public interface ISpell
{
    List<ElementType> GetElementsCombination();
    ISpellCaster FindCasterComponent();
    SpellAttribute GetSpellAttribute();
    void SetSpellAttribute(SpellAttribute attribute);
    ElementType GetPrincipalElementType();
    float GetManaCost();
}