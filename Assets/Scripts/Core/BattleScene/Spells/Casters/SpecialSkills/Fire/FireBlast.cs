using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : AbstractSpellCaster
{
    public GameObject explosionPrefab;
    private GameObject playerGameobj;

    [SerializeField] private float explosionScale = 2f;
    [SerializeField] private float damage = 100f;
    [SerializeField] private float forceFactor = 10f;

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
        explosionController.Scale = explosionScale;
        explosionController.HasForce = true;
        explosionController.ForceFactor = forceFactor;
        playerGameobj.GetComponent<PlayerController>().TemporarySpeedUp(3f, 0.2f);
    }
}
