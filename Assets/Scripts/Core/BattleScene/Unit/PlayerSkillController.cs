using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
	private PlayerAttribute playerAttribute;

	private PlayerController playerController;

	private BattleSceneMainUIController uiController;

	private List<ElementType> conjuredElements = new List<ElementType>();
	private List<ElementType> spellElements = new List<ElementType>();

	private SpellMatcher spellMatcher = new SpellMatcher();

	[SerializeField] private ConjureTable conjureTable;
	private PlayerAnimeController animeController;

	private void Start()
	{
		playerAttribute = Utils.GetPlayerAttribute();
		playerController = Utils.GetPlayerObject().GetComponent<PlayerController>();
		uiController = Utils.GetMainUIController();
		animeController = GameObject.FindGameObjectWithTag("PlayerAnimation").GetComponent<PlayerAnimeController>();
	}

	private void Update()
	{
		HandleKeyInput();
	}

	private void HandleKeyInput()
	{
		// element table full
		if (IsConjureTableFull() && !Input.GetKeyDown(KeyCode.Space))
			return;

		HandleElementKeyInput(KeyCode.Alpha1, ElementType.Fire);
		HandleElementKeyInput(KeyCode.Alpha2, ElementType.Water);
		HandleElementKeyInput(KeyCode.Alpha3, ElementType.Wind);
		HandleElementKeyInput(KeyCode.Alpha4, ElementType.Soil);

		if (Input.GetKeyDown(KeyCode.Space) && !IsConjureTableEmpty())
		{
			animeController.PlayerAttack();
			
			PushConjuredElementsToSpell();
			ClearConjuredElements();
			TriggerSpell();
		}
	}

	private void HandleElementKeyInput(KeyCode key, ElementType element)
	{
		bool hasEnoughMana = playerAttribute.CurrentMana >= Constants.ElementManaCost;
		if (Input.GetKeyDown(key))
		{
			if (hasEnoughMana)
			{
				AppendElement(element);
			}
			else
			{
				uiController.ShakeManaBar();
			}
		}
	}

	private void TriggerSpell()
	{
		ISpell spell = spellMatcher.MatchSpell(GetSpellElements(), playerAttribute.CurrentMana);
		ISpellCaster caster = spell.FindCasterComponent();
		playerController.CostMana(spell.GetManaCost());
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
		// cost mana
		playerController.CostMana(Constants.ElementManaCost);
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

	public bool IsConjureTableFull()
	{
		return conjuredElements.Count >= GetConjuredElementsLimit();
	}

	public bool IsConjureTableEmpty()
	{
		return conjuredElements.Count == 0;
	}
}
