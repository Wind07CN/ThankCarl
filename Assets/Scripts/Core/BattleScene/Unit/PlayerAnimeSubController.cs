using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimeSubController : MonoBehaviour
{
	private Animator animator;
	private void Start()
	{
		animator = GetComponent<Animator>();
	}


	private void ResetBody()
	{
		animator.SetBool("attack", false);
	}

	public void ShowEndUI()
	{
		Utils.GetMainUIController().ShowEndUI();
	}
}
