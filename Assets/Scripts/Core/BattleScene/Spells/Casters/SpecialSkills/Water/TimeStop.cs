using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : AbstractSpellCaster
{
    [SerializeField] private GameObject stopTimeUI;
    [SerializeField] private float durationTime = 5f;

    [SerializeField] private float stunTime = 0.7f;
    private bool isActive = false;
    [SerializeField] private float intervalTIme = 1f;
    private float stunTimer = 0;



    private void Start()
    {
        stopTimeUI.SetActive(false);
        isActive = false;
    }

    private void Update()
    {
        if (isActive)
        {
            if (stunTimer > 0)
            {
                stunTimer -= Time.deltaTime;
            }
            else
            {
                stunTimer = intervalTIme;
                foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    enemy.GetComponent<EnemyController>().StunEnemy(stunTime);
                }
            }

        }
    }

    public override void Cast(ISpell spell)
    {
        stopTimeUI.SetActive(true);
        isActive = true;
        Invoke(nameof(EndStopTime), durationTime);

    }

    private void EndStopTime()
    {
        stopTimeUI.SetActive(false);
        isActive = false;
    }

}
