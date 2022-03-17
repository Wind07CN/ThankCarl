using UnityEngine;

public class Tornado : AbstractSpellCaster
{

    public GameObject TomadoPrefab;
    private GameObject playerGameObj;

    private void Start()
    {
        playerGameObj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {
        Instantiate(TomadoPrefab, playerGameObj.transform.position, Quaternion.identity);
    }
}
