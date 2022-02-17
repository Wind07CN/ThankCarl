using System.Collections.Generic;

public interface ISpell
{
    List<ElementType> GetElementsCombination();
    ISpellCaster FindCasterComponent();
    SpellAttribute GetSpellAttribute();
}