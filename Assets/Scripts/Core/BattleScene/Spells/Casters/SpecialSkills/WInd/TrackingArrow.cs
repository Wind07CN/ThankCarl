using System.Collections;
using UnityEngine;

public class TrackingArrow : AbstractSpellCaster
{

    public GameObject ArrowPrefab;
    public int ArrowNumber = 3;
    public float Interval = 0.4f;
    private GameObject playerGameObj;

    private void Start()
    {
        playerGameObj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {
        Vector3 cursorAngle = new Vector3(0, 0, playerGameObj.GetComponent<PlayerMoveController>().GetMouseAngle());
        StartCoroutine(ShootArrowCoroutine(cursorAngle, ArrowNumber, Interval));

    }

    private IEnumerator ShootArrowCoroutine(Vector3 angle, int repeat, float delay)
    {
        for (int i = 0; i < repeat; i++)
        {
            GameObject arrow = Instantiate(ArrowPrefab, playerGameObj.transform.position, Quaternion.identity);
            arrow.transform.eulerAngles = angle;
            yield return new WaitForSeconds(delay);
        }
    }
}
