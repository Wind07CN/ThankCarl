using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSceneMainUIController : MonoBehaviour
{

    private PlayerAttribute playerAttribute;
    [SerializeField] private GameObject shakeUI;

    [SerializeField] private Text playerPointText;
    [SerializeField] private LifeBar lifeBar;
    [SerializeField] private ManaBar manaBar;

    [SerializeField] private Image avatar;
    [SerializeField] private Sprite[] charactorSprites;
    [SerializeField] private GameObject getDameage;
    [SerializeField] private float shakeRange = 10f;
    [SerializeField] private float shakeTime = 0.15f;

    [SerializeField] private GameObject endUI;

    [SerializeField] private GameObject getNewSkillUI;
    [SerializeField] private GameObject getNewElementUI;
    [SerializeField] private Transform getUI;

    [SerializeField] private ConjureTable conjureTable;

    private Vector3 shakePos = Vector3.zero;

    private bool isShake = false;
    private bool isDying = false;

    private void Awake()
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
        avatar.sprite = charactorSprites[Utils.GetDataRecord().currentCharactorNum];
    }

    public void UpdateAllUI() 
    {
        playerAttribute = Utils.GetPlayerAttribute();
        UpdateLifeBar();
        UpdateManaBar();
        UpdatePointText();
    }

    public void UpdatePointText()
    {
        playerPointText.text = string.Format("{0:D8}", playerAttribute.PlayerPoints);
    }

    public void UpdateManaBar()
    {
        manaBar.shouldUpdate = true;
    }

    public void ShakeManaBar()
    {
        manaBar.Shake();
    }

    public void UpdateLifeBar()
    {
        lifeBar.shouldUpdate = true;
    }

    public void Addconjure()
    {
        conjureTable.UnlockConjure();
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

    public void ShowEndUI()
    {
        Instantiate(endUI, transform);
        getDameage.SetActive(false);
    }

    public void ShowGetNewSkillUI() 
    {
        Instantiate(getNewSkillUI, getUI);
    }

    public void ShowGetNewElementUI()
    {
        Instantiate(getNewElementUI, getUI);
    }
}
