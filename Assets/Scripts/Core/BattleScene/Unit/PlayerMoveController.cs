using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    // [SerializeField]
    private PlayerAttribute mPlayerAttribute;
    private PlayerAnimeController animeController;

    [SerializeField] private float maxRangeX1 = -60f;
    [SerializeField] private float maxRangeX2 = 60f;
    [SerializeField] private float maxRangeY1 = 30f;
    [SerializeField] private float maxRangeY2 = -30f;

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
            HandleKeyBoardInput();
        }
    }

    private void HandleKeyBoardInput()
    {
        bool isRun = false;
        Vector2 direction = Vector2.zero;

        // Debug.Log(Camera.main.WorldToScreenPoint(transform.position) + "+" + Input.mousePosition);

        if (Camera.main.WorldToScreenPoint(transform.position).x > Input.mousePosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        if (Input.GetKey(KeyCode.W) && transform.position.y <= maxRangeY1)
        {
            isRun = true;
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >= maxRangeY2)
        {
            isRun = true;
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x >= maxRangeX1)
        {
            isRun = true;
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= maxRangeX2)
        {
            isRun = true;
            direction += Vector2.right;
        }
        if (isRun != isLastStateRun)
        {
            animeController.PlayMoveState(isRun);
            isLastStateRun = isRun;
        }
        transform.Translate(mPlayerAttribute.MoveSpeed * Time.deltaTime * direction.normalized);
    }

    public float GetMouseAngle()
    {
        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Utils.GetTwoPointsEulerAngle(transform.position, mPos);
    }

}
