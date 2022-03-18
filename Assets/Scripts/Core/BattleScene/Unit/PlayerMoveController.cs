using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private PlayerAttribute mPlayerAttribute;
    private PlayerAnimeController animeController;

    public float MinX = -100f;
    public float MaxX = 30f;
    public float MaxY = 48f;
    public float MinY = -25f;

    private bool isLastStateRun = false;

    private void Start()
    {
        mPlayerAttribute = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().playerAttribute;
        animeController = GameObject.FindGameObjectWithTag("PlayerAnimation").GetComponent<PlayerAnimeController>();
    }

    private void Update()
    {
        if (mPlayerAttribute.IsActive && mPlayerAttribute.IsAlive)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        bool isRun = false;
        Vector2 direction = Vector2.zero;

        // Debug.Log(Camera.main.WorldToScreenPoint(transform.position) + "+" + Input.mousePosition);

        // spriate orientation, left or right
        AdjustSpriteOrientation();

        if (!IsInsideMapRange(transform.position))
        {
            return;
        }

        // if left mouse is held
        if (Input.GetMouseButton(0))
        {
            isRun = true;
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        else
        {
            isRun = false;
        }

        // animation control
        if (isRun != isLastStateRun)
        {
            animeController.PlayMoveState(isRun);
            isLastStateRun = isRun;
        }

        Vector2 moveVector = mPlayerAttribute.MoveSpeed * Time.deltaTime * direction.normalized;
        Vector3 targetPosition = new Vector2(transform.position.x, transform.position.y) + moveVector;

        if (IsInsideMapRange(targetPosition))
        {
            MovePlayer(moveVector);
        }
    }


    private void MovePlayer(Vector3 vec)
    {
        transform.Translate(vec);
    }

    public bool IsInsideMapRange(Vector2 pos)
    {
        if (pos.x < MinX || pos.x > MaxX || pos.y < MinY || pos.y > MaxY)
        {
            return false;
        }
        return true;
    }

    public Vector2 GetLimitedPosition(Vector2 pos)
    {
        Vector2 newPos = new Vector2(pos.x, pos.y);
        if (pos.x < MinX)
        {
            pos.x = MinX;
        }
        else if (pos.x > MaxX)
        {
            pos.x = MaxX;
        }

        if (pos.y < MinY)
        {
            pos.y = MinY;
        }
        else if (pos.y > MaxY)
        {
            pos.y = MaxY;
        }

        return pos;
    }

    private void AdjustSpriteOrientation()
    {
        if (Camera.main.WorldToScreenPoint(transform.position).x > Input.mousePosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public float GetMouseAngle()
    {
        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Utils.GetTwoPointsEulerAngle(transform.position, mPos);
    }

}
