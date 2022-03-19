using UnityEngine;

public class LightningBallController : MonoBehaviour
{

    [HideInInspector] public ElementType ElementType = ElementType.Wind;
    [HideInInspector] public float Speed = 5f;
    [HideInInspector] public float CollisionDamage = 2f;
    [HideInInspector] public GameObject LightningChainPrefab;

    [SerializeField] private float autoDestructionTime = 10f;

    private void Start()
    {
        Destroy(gameObject, autoDestructionTime);
    }

    private void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector3.up, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.EnemyTag))
        {
            SpellDamageDealer.Deal(ElementType, collision.gameObject, CollisionDamage);
            Utils.GetHitEffectGenerator().InitHitEffect(ElementType, collision.gameObject, new Vector3(0.5f, 1f, 0));
            GameObject chain = Instantiate(LightningChainPrefab, transform.position, Quaternion.identity);
            LightningChainController chainController = chain.GetComponent<LightningChainController>();
            chainController.InitialEnemy = collision.gameObject;
            chainController.Damage = CollisionDamage;
            Destroy(gameObject);
        }
    }

}
