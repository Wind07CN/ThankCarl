using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSceneMainUIController : MonoBehaviour
{

	private PlayerAttribute playerAttribute;
	[SerializeField] private GameObject shakeUI;

	[SerializeField] private GameObject playerLevelIndicator;
	[SerializeField] private GameObject playerLifeBar;
	[SerializeField] private GameObject playerManaBar;

	[SerializeField] private GameObject getDameage;
	[SerializeField] private float shakeRange = 10f;
	[SerializeField] private float shakeTime = 0.15f;

	private Text playerLevelText;
	private ManaBar manaBar;
	private LifeBar lifeBar;

	private Vector3 shakePos = Vector3.zero;

	private bool isShake = false;
	private bool isDying = false;

	private void Start()
	{
		InitMainUI();
	}

	private void Update()
	{
		if (isShake)
		{
			ShakeUI();
		}
	}
	private void InitMainUI()
	{
		playerAttribute = Utils.GetPlayerAttribute();

		playerLevelText = playerLevelIndicator.GetComponent<Text>();

		lifeBar = playerLifeBar.GetComponent<LifeBar>();
		manaBar = playerManaBar.GetComponent<ManaBar>();
		lifeBar.shouldUpdate = true;
		manaBar.shouldUpdate = true;
	}

	public void UpdateLevelIndicatorUI()
	{
		playerLevelText.text = "Lv." + playerAttribute.Level;
	}

	public void UpdateManaBar()
	{
		manaBar.shouldUpdate = true;
	}

	public void UpdateLifeBar()
	{
		lifeBar.shouldUpdate = true;
	}

	public void GetDamage()
	{
		if (!isDying) 
		{
			getDameage.SetActive(true);
			Invoke(nameof(ResetGetDamage), shakeTime);
		}
		isShake = true;
		Invoke(nameof(StopShake), shakeTime);
	}

	private void ResetGetDamage()
	{
		getDameage.SetActive(false);
		shakeUI.transform.localPosition = Vector3.zero;
	}

	private void StopShake() 
	{
		isShake = false;
	}

	private void ShakeUI()
	{
		shakeUI.transform.localPosition += shakePos;
		shakePos = Random.insideUnitSphere * shakeRange;
		shakeUI.transform.localPosition -= shakePos;
	}

	public void PlayerIsDying()
	{
		isDying = true;
		getDameage.SetActive(true);
	}
	
	public void PlayerIsNotDying()
	{
		isDying = false;
		getDameage.SetActive(false);
	}


}
