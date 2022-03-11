using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
	private PlayerAttribute playerAttribute;

	private List<ElementType> conjuredElements = new List<ElementType>();
	private List<ElementType> spellElements = new List<ElementType>();

	private SpellMatcher spellMatcher = new SpellMatcher();

	[SerializeField] private ConjureTable conjureTable;
	private PlayerAnimeController animeController;

	private void Start()
	{
		playerAttribute = Utils.GetPlayerAttribute();
		
		animeController = GameObject.FindGameObjectWithTag("PlayerAnimation").GetComponent<PlayerAnimeController>();
	}

	private void Update()
	{
		HandleKeyInput();
	}

	private void HandleKeyInput()
	{
		if (IsConjuredTableFull() && !Input.GetKeyDown(KeyCode.Space))
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			AppendElement(ElementType.Fire);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			AppendElement(ElementType.Water);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			AppendElement(ElementType.Wind);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			AppendElement(ElementType.Soil);
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			animeController.PlayerAttack();
			
			PushConjuredElementsToSpell();
			ClearConjuredElements();
			TriggerSpell();
		}

	}

	private void TriggerSpell()
	{
		ISpell spell = spellMatcher.MatchSpell(GetSpellElements());
		ISpellCaster caster = spell.FindCasterComponent();
		caster.Cast(spell.GetSpellAttribute());
	}

	public List<ElementType> GetConjuredElements()
	{
		return conjuredElements;
	}

	public List<ElementType> GetSpellElements()
	{
		return spellElements;
	}

	public void AppendElement(ElementType element)
	{
		if (conjuredElements.Count < GetConjuredElementsLimit())
		{
			conjuredElements.Add(element);
			conjureTable.UpdateElement(conjuredElements.Count, element);
		}
	}

	public void ClearConjuredElements()
	{
		conjuredElements.Clear();
		conjureTable.ClearElement();
	}

	public void PushConjuredElementsToSpell()
	{
		spellElements.Clear();
		spellElements.AddRange(conjuredElements);
	}

	public int GetConjuredElementsLimit()
	{
		return playerAttribute.Level + Constants.BaseConjuredElementsAmount - 1;
	}

	public bool IsConjuredTableFull()
	{
		return conjuredElements.Count >= GetConjuredElementsLimit();
	}

	public bool IsConjureTableEmpty()
	{
		return conjuredElements.Count == 0;
	}
}
