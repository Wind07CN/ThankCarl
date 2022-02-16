using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellMatcher
{
    // use Set if order doesn't matter
    private List<ISpell> spells = new List<ISpell>();
    private Spell<General> generalSpell = new Spell<General>();

    /*
     * Register all the spells here.
     */
    public SpellMatcher()
    {
        this.spells.Add(new Spell<FireBall>(ElementType.Fire));
        this.spells.Add(new Spell<Whirl>(ElementType.Water));
    }

    public ISpell MatchSpell(List<ElementType> elements)
    {
        foreach (ISpell spell in this.spells)
        {
            if (spell.GetElementsCombination().Count != elements.Count)
            {
                continue;
            }
            if (Enumerable.SequenceEqual(spell.GetElementsCombination(), elements))
            {
                return spell;
            }
        }
        return generalSpell;
    }

}