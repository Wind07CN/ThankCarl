using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimeController : MonoBehaviour
{
	private  Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void EnemyDead() 
	{
		animator.SetBool("dead", true);
	}

	private void DestroyGameObject() 
	{
		Destroy(gameObject);
	}
}
