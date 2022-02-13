using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Enemy enemy;

    private PlayerController playerContoller;

    public void Start()
    {
        enemy = new Enemy();
        playerContoller = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerController>();
    }

    public void Update()
    {
        if (enemy.IsAlive)
        {
            TrackPlayer();
        }
    }

    public void DamageEnemy()
    {

    }

    private void TrackPlayer()
    {
        Vector2 orientation = playerContoller.transform.position - transform.position;

        float angle = Mathf.Atan2(orientation.y, orientation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Translate(Vector2.right * enemy.MoveSpeed * Time.deltaTime);
    }
}