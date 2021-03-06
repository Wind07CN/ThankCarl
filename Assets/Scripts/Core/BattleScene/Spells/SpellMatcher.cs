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
        // Fire Skills
        this.spells.Add(new Spell<FireBall>(10, ElementType.Fire, ElementType.Fire)); 
        this.spells.Add(new Spell<FireBlast>(10, ElementType.Fire, ElementType.Wind));
        this.spells.Add(new Spell<Meteorite>(40, ElementType.Fire, ElementType.Earth, ElementType.Earth));
        this.spells.Add(new Spell<LaserBlast>(20, ElementType.Fire, ElementType.Wind, ElementType.Water));
        this.spells.Add(new Spell<Phoenix>(70, ElementType.Fire, ElementType.Fire, ElementType.Fire, ElementType.Water, ElementType.Wind));

        // Water Skills
        this.spells.Add(new Spell<Whirl>(10, ElementType.Water, ElementType.Wind));
        this.spells.Add(new Spell<WaterDropProtector>(40, ElementType.Water, ElementType.Wind, ElementType.Wind));
        this.spells.Add(new Spell<WaterBulletStorm>(20, ElementType.Water, ElementType.Fire, ElementType.Earth));
        this.spells.Add(new Spell<MagicCircle>(30, ElementType.Water, ElementType.Water, ElementType.Earth, ElementType.Earth));
        this.spells.Add(new Spell<TimeStop>(20, ElementType.Water, ElementType.Water, ElementType.Earth, ElementType.Wind, ElementType.Wind));


        // Earth Skills
        this.spells.Add(new Spell<Shotgun>(30, ElementType.Earth, ElementType.Water));
        this.spells.Add(new Spell<RollingStone>(10, ElementType.Earth, ElementType.Fire));
        this.spells.Add(new Spell<DefensiveWalls>(10, ElementType.Earth, ElementType.Earth));
        this.spells.Add(new Spell<CannonTower>(40, ElementType.Earth, ElementType.Fire, ElementType.Wind, ElementType.Water));
        this.spells.Add(new Spell<Schutzwall>(40, ElementType.Earth, ElementType.Earth, ElementType.Earth, ElementType.Wind, ElementType.Fire));


        // Wind Skill 
        this.spells.Add(new Spell<TrackingArrow>(10, ElementType.Wind, ElementType.Wind));
        this.spells.Add(new Spell<Tornado>(20, ElementType.Wind, ElementType.Water, ElementType.Wind));
        this.spells.Add(new Spell<Teleport>(10, ElementType.Wind, ElementType.Wind, ElementType.Earth));
        this.spells.Add(new Spell<LightningChain>(30, ElementType.Wind, ElementType.Wind, ElementType.Fire, ElementType.Fire));
        this.spells.Add(new Spell<Thunder>(70, ElementType.Wind, ElementType.Wind, ElementType.Fire, ElementType.Fire, ElementType.Water));

        // general spells require only one element
        this.generalSpells.Add(new Spell<FireGeneral>(0, ElementType.Fire));
        this.generalSpells.Add(new Spell<WaterGeneral>(0, ElementType.Water));
        this.generalSpells.Add(new Spell<EarthGeneral>(0, ElementType.Earth));
        this.generalSpells.Add(new Spell<WindGeneral>(0, ElementType.Wind));

        // order spells by mana cost so that the spells with higher come first
        spells = spells.OrderByDescending(spell => spell.GetManaCost()).ToList();
    }
    public ISpell MatchSpell(List<ElementType> elements, float currentMana)
    {
        int spellNum = 0;
        // spells should be sorted by mana cost so that the spells with higher come first
        foreach (ISpell spell in this.spells)
        {
            if (IsSpellMatched(spell, elements) && currentMana >= spell.GetManaCost())
            {
                // use another checker to check the skill avoid caton
                Utils.GetSkillChecker().CheckSpell(spellNum);
                return spell;
            }
            spellNum++;
        }
        // general spells have no additional cost, they should be compared after any other spells
        // the match of general spells is decided by the principle element
        return MatchGeneralSpell(elements);

        throw new System.Exception("Unexpected error when matching spell. Did you forget to register a spell?");
    }
    private bool IsSpellMatched(ISpell spell, List<ElementType> elements)
    {
        if (spell.GetElementsCombination().Count != elements.Count)
        {
            return false;
        }


        if (elements[0] != spell.GetPrincipalElementType())
        {
            return false;
        }

        List<ElementType> orderedInputElements = elements.GetRange(1, elements.Count - 1).OrderBy(element => element).ToList();
        List<ElementType> orderedSpellElements = spell.GetElementsCombination().GetRange(1, spell.GetElementsCombination().Count - 1)
                                                    .OrderBy(element => element).ToList();

        if (!Enumerable.SequenceEqual(orderedInputElements, orderedSpellElements))
        {
            return false;
        }

        return true;
    }

    private ISpell MatchGeneralSpell(List<ElementType> elements)
    {
        foreach (ISpell spell in this.generalSpells)
        {
            if (spell.GetPrincipalElementType() == elements[0])
            {
                switch (elements[0])
                {
                    case ElementType.Fire:
                        return new Spell<FireGeneral>(0, elements.ToArray());
                    case ElementType.Water:
                        return new Spell<WaterGeneral>(0, elements.ToArray());
                    case ElementType.Earth:
                        return new Spell<EarthGeneral>(0, elements.ToArray());
                    case ElementType.Wind:
                        return new Spell<WindGeneral>(0, elements.ToArray());
                    default:
                        throw new System.Exception("Unexpected error when matching general spell");
                }
            }
        }
        throw new System.Exception("Unexpected error when matching general spell");
    }

}