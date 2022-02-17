using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Image image;
    private PlayerAttribute mPlayer;
    private void Start()
    {
        image = GetComponent<Image>();
        mPlayer = GameObject.FindWithTag("MainController").GetComponent<BattleSceneController>().player;
    }

    private void Update()
    {
        UpdateLifeBarPercentage(mPlayer.MaxLife, mPlayer.CurrentLife);
    }

    private void UpdateLifeBarPercentage(float totalHealth, float currentHealth)
    {
        image.fillAmount = currentHealth / totalHealth;
    }
}
