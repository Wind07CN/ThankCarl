using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;

    public void Start()
    {
        player = new Player();
    }

    private void Update()
    {
        if (player.IsAlive)
        {
            HandleKeyBoardInput();
        }
        else
        {	
            Debug.Log("Player Dead!");
        }
    }

    public void DamagePlayer()
    {
        player.CurrentLife -= 10;
    }
    
    public void DamagePlayer(int damage)
    {
        player.CurrentLife -= damage;
    }

    private void HandleKeyBoardInput()
    {
        float moveDistance = Time.deltaTime * player.MoveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * moveDistance);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * moveDistance);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * moveDistance);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveDistance);
        }
    }

}
