using System.Collections.Generic;
using System.Linq;

public class SpellMatcher
{
    // use Set if order doesn't matter
    private List<ISpell> spells = new List<ISpell>();
    private List<ISpell> generalSpells = new List<ISpell>();

    /*
     * Register all the spells here.
     */
    public SpellMatcher()
    {
        this.spells.Add(new Spell<FireBall>(0, ElementType.Fire));
        this.spells.Add(new Spell<Whirl>(10, ElementType.Water));

        // general spells require only one element
        // this.generalSpells.Add(new Spell<Whirl>(0, ElementType.Water));
        
        // order spells by mana cost so that the spells with higher come first
        spells = spells.OrderByDescending(spell => spell.GetManaCost()).ToList();
    }

    public ISpell MatchSpell(List<ElementType> elements, float currentMana)
    {
        // spells should be sorted by mana cost so that the spells with higher come first
        foreach (ISpell spell in this.spells)
        {
            if (spell.GetElementsCombination().Count != elements.Count)
            {
                continue;
            }

            if (Enumerable.SequenceEqual(spell.GetElementsCombination(), elements)
                && currentMana >= spell.GetManaCost())
            {
                return spell;
            }
        }
        // general spells have no additional cost, they should be compared after any other spells
        // the match of general spells is decided by the principle element
        return MatchGeneralSpell(elements);

        throw new System.Exception("Unexpected error when matching spell. Did you forget to register a spell?");
        
    }

    private ISpell MatchGeneralSpell(List<ElementType> elements)
    {
        foreach (ISpell spell in this.generalSpells)   
        {
            if (spell.GetPrincipalElementType() == elements[0])
            {
                return spell;
            }
        }
        throw new System.Exception("Unexpected error when matching general spell");
    }

}