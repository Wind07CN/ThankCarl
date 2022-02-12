using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
	private Image image;
	private Player player;
	private void Start()
	{
		image = GetComponent<Image>();
		image.fillAmount = 1f;
		player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerController>().player;
		
	}

	private void Update()
	{
		if (player != null)
		{
			SetPlayerHealth(player.TotalHealth, player.CurrentHealth);
		}
	}

	// 玩家扣血的时候需要调用这个函数
	public void SetPlayerHealth(float totalHealth, float currentHealth)
	{
		image.fillAmount = currentHealth / totalHealth;
	}
}
