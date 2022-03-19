using UnityEngine;

public class LightningChain : AbstractSpellCaster
{
    public GameObject LightningBallPrefab;
    public GameObject LightningChainPrefab;
    public ElementType ElementType = ElementType.Wind;
    public float MaxCaptureDistance = 10f;
    public float EffectExistTime = 1f;
    public float EffectDisappearTime = 0.5f;
    public float Damage = 20f;
    public float BulletSpeed = 30f;
    public int MaxJumpCount = 3;

    private GameObject playerGameObj;

    private void Start()
    {
        playerGameObj = Utils.GetPlayerObject();
        LightningChainController chainPrefabController = LightningChainPrefab.GetComponent<LightningChainController>();
        chainPrefabController.MaxCaptureDistance = MaxCaptureDistance;
        chainPrefabController.EffectExistTime = EffectExistTime;
        chainPrefabController.EffectDisappearTime = EffectDisappearTime;
        chainPrefabController.Damage = Damage;
        chainPrefabController.MaxJumpCount = MaxJumpCount;
    }

    public override void Cast(ISpell spell)
    {
        GameObject lightningBall = Instantiate(LightningBallPrefab, playerGameObj.transform.position, Quaternion.identity);
        LightningBallController controller = lightningBall.GetComponent<LightningBallController>();
        controller.ElementType = ElementType;
        controller.CollisionDamage = Damage;
        controller.Speed = BulletSpeed;
        controller.LightningChainPrefab = LightningChainPrefab;

        lightningBall.transform.eulerAngles = new Vector3(0, 0, playerGameObj.GetComponent<PlayerMoveController>().GetMouseAngle());
    }
}
