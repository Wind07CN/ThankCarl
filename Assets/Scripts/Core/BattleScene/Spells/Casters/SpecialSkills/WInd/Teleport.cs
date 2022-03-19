using UnityEngine;

public class Teleport : AbstractSpellCaster
{
    public GameObject EffectPrefab;
    public float MaxRange = 20f;
    private GameObject playerObj;
    private PlayerMoveController playerMoveController;
    private bool isCameraDamping = false;

    private void Start()
    {
        playerObj = Utils.GetPlayerObject();
        playerMoveController = playerObj.GetComponent<PlayerMoveController>();
    }

    private void LateUpdate()
    {
        if (isCameraDamping)
        {
           Vector3 positionError = playerObj.transform.position - Camera.main.transform.position;
           if (positionError.magnitude <= 0) ResetCamera();
        }
    }

    public override void Cast(ISpell spell)
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPosition = GetLimitedPosition(cursorPosition);
        GenerateEffect(playerObj.transform.position, targetPosition);
        SetTemporaryDampingCamera(0.15f);
        playerObj.transform.position = targetPosition;
    }

    private void GenerateEffect(Vector2 originPosition, Vector2 targetPosition)
    {
        GameObject targetEffect = Instantiate(EffectPrefab, targetPosition, Quaternion.identity);
        GameObject originEffect = Instantiate(EffectPrefab, originPosition, Quaternion.identity);
    }

    private Vector2 GetLimitedPosition(Vector2 pos)
    {
        Vector2 moveVector = pos - (Vector2)playerObj.transform.position;
        if (moveVector.magnitude > MaxRange)
        {
            moveVector = moveVector.normalized * MaxRange;
        }

        Vector2 limitedInMapPosition = playerMoveController.GetLimitedPosition((Vector2)playerObj.transform.position + moveVector);
        return limitedInMapPosition;
    }

    private void SetTemporaryDampingCamera(float smoothTime)
    {
        Camera.main.GetComponent<CameraController>().SmoothTime = smoothTime;
        isCameraDamping = true;
    }

    private void ResetCamera()
    {
        Camera.main.GetComponent<CameraController>().SmoothTime = 0;
        isCameraDamping = false;
    }
}