using UnityEngine;

public class FireBall : AbstractSpellCaster
{
    public GameObject FireBallPrefab;
    private GameObject playerGameobj;

    private void Start()
    {
        playerGameobj = Utils.GetPlayerObject();
    }
    
    public override void Cast(ISpell spell)
    {
        GameObject gameObject = Instantiate(FireBallPrefab, playerGameobj.transform.position, Quaternion.identity);
        gameObject.transform.eulerAngles = new Vector3(0, 0, playerGameobj.gameObject.GetComponent<PlayerMoveController>().GetMouseAngle());
    }
}