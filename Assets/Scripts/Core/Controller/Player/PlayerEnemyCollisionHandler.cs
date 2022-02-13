using UnityEngine;

public class PlayerEnemyCollisionHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			Debug.Log("Boom!!!!!!");
			gameObject.GetComponent<PlayerController>().DamagePlayer();
			Destroy(collision.gameObject);
		}
	}

}