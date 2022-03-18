using UnityEngine;

public class Teleport : AbstractSpellCaster
{
    public GameObject EffectPrefab;
    public float MaxRange = 20f;
    private GameObject playerObj;
    private PlayerMoveController playerMoveController;

    private void Start()
    {
        playerObj = Utils.GetPlayerObject();
        playerMoveController = playerObj.GetComponent<PlayerMoveController>();
    }

    public override void Cast(ISpell spell)
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPosition = GetLimitedPosition(cursorPosition);
        GenerateEffect(playerObj.transform.position, targetPosition);
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
}