using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimeController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("dead", false);
        animator.SetBool("attack", false);
        animator.SetBool("getDamage", false);
        animator.SetBool("isRun", false);

    }

    private void Start()
    {
        if (animator == null)
        {

        }
    }

    public void PlayMoveState(bool isRun)
    {
        animator.SetBool("isRun", isRun);
    }

    public void PlayerIsDead()
    {
        animator.SetBool("dead", true);
    }

    public void PlayerGetDamage()
    {
        animator.SetBool("getDamage", true);
        Invoke(nameof(ResetFace), 0.5f);
    }

    public void PlayerAttack()
    {
        animator.SetBool("attack", true);
    }

    private void ResetFace()
    {
        animator.SetBool("getDamage", false);
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
