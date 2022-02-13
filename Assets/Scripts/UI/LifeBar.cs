using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<PlayerController>().player;
        UpdateLifeBarPercentage(player.MaxLife, player.CurrentLife);
    }

    private void UpdateLifeBarPercentage(float totalHealth, float currentHealth)
    {
        image.fillAmount = currentHealth / totalHealth;
    }
}
