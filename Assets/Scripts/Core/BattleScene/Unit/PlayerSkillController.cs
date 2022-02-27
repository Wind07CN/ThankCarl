using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
	private PlayerAttribute playerAttribute;

	private List<ElementType> conjuredElements = new List<ElementType>();
	private List<ElementType> spellElements = new List<ElementType>();

	private SpellMatcher spellMatcher = new SpellMatcher();

	private ConjureTable conjureTable;
	private PlayerAnimeController animeController;

	private void Start()
	{
		playerAttribute = Utils.GetPlayerAttribute();
		conjureTable = GameObject.Find("ConjureTable").GetComponent<ConjureTable>();
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
			AppendElement(ElementType.Air);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			AppendElement(ElementType.Earth);
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			animeController.PlayerAttack();
			PushConjuredElementsToSpell();
			ClearConjuredElements();
			TriggerSpell();
		}

		conjureTable.UpdateConjureTableUI();
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
		}
		else
		{
			throw new System.Exception("Conjured Elements is full!");
		}
	}

	public void ClearConjuredElements()
	{
		conjuredElements.Clear();
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
