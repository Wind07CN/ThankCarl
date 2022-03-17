using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    [SerializeField] private GameObject scorchZonePrefab;
    [SerializeField] private GameObject areaEffectPrefab;

    public int ExplosionDamage = 100;
    public int ScorchDamage = 15;

    [SerializeField] private float fallHeight = 100;
    [SerializeField] private float fallTime = 1;

    public float explosionRange = 1f;
    public bool hasForce = true;
    public float forceFactor = 30f;


    private Vector3 targetPos;
    private float fallSpeed;

    private void Awake()
    {
        targetPos = transform.position;
        fallSpeed = fallHeight / fallTime;
        transform.position += fallHeight * new Vector3(-1, 1, 0);
    }

    private void Update()
    {
        if (fallTime > 0)
        {
            fallTime -= Time.deltaTime;
            transform.position -= fallSpeed * Time.deltaTime * new Vector3(-1, 1, 0);
        }
        else
        {
            GenerateExplosion();
            GenerateScorchZone();
            Destroy(gameObject);
        }
    }

    private void GenerateExplosion()
    {
        ExplosionController explosionController = Instantiate(areaEffectPrefab,
            targetPos, Quaternion.identity).GetComponent<ExplosionController>();
        explosionController.Damage = ExplosionDamage;
        explosionController.Scale = explosionRange;
        explosionController.HasForce = hasForce;
        explosionController.ForceFactor = forceFactor;
    }

    private void GenerateScorchZone()
    {
        ScorchZoneController scorchZoneController = Instantiate(scorchZonePrefab,
            targetPos, Quaternion.identity).GetComponent<ScorchZoneController>();
        scorchZoneController.Damage = ScorchDamage;
        scorchZoneController.scaleRatio = explosionRange;
    }
}
