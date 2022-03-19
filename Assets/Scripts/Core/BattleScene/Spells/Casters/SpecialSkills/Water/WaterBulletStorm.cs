using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBulletStorm : AbstractSpellCaster
{
    public GameObject BulletPrefab;
    public int RoundCount = 1;
    public int BulletCount = 30;
    public float Interval = 0.05f;
    private GameObject playerGameObj;

    private void Start()
    {
        playerGameObj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {
        Vector3 initialAngle = new Vector3(0, 0, playerGameObj.GetComponent<PlayerMoveController>().GetMouseAngle());
        StartCoroutine(ShootBulletsCoroutine(initialAngle, BulletCount, RoundCount, Interval));
    }

    private IEnumerator ShootBulletsCoroutine(Vector3 initialAngle, int repeat, int rounds, float delay)
    {
        for (int i = 0; i < repeat; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab, playerGameObj.transform.position, Quaternion.identity);
            float angle = initialAngle.z - i * rounds * 360f / repeat;
            bullet.transform.eulerAngles = new Vector3(0, 0, angle);
            yield return new WaitForSeconds(delay);
        }
    }
}
