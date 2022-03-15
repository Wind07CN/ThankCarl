using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : AbstractSpellCaster
{
    public GameObject explosionPrefab;
    private GameObject playerGameobj;

    [SerializeField] private float exploosionScale = 2f;
    [SerializeField] private float damage = 100f;
    [SerializeField] private float ForceFactor = 10f;

    private void Start()
    {
        playerGameobj = Utils.GetPlayerObject();
    }

    public override void Cast(ISpell spell)
    {
        GameObject explosion = Instantiate(explosionPrefab, playerGameobj.transform.position, Quaternion.identity);
        ExplosionController explosionController = explosion.GetComponent<ExplosionController>();
        explosionController.Damage = damage;
        explosionController.ElementType = ElementType.Fire;
        explosionController.Scale = exploosionScale;
        explosionController.HasForce = true;
        explosionController.ForceFactor = ForceFactor;
        playerGameobj.GetComponent<PlayerController>().QuickDash(20, 0.2f);
    }
}
