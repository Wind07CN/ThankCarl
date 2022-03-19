using System.Collections.Generic;
using UnityEngine;

public class TrackingProjectileController : LinearProjectileController
{
    public float DetectEnemyRadius = 10f;
    public float TurningSpeed = 300f;

    private GameObject lockedEnemy;

    private void Update()
    {
        lockedEnemy = Utils.FindTheNearestEnemy(transform.position, DetectEnemyRadius);
        if (lockedEnemy != null)
        {
            float selfToTargetAngle = Vector2.SignedAngle(Vector2.down, lockedEnemy.transform.position - transform.position) + 360;
            float selfOrientationAngle = transform.rotation.eulerAngles.z;
            float turningAngle = GetTurningDirection(selfToTargetAngle, selfOrientationAngle) * Mathf.Min(
                TurningSpeed * Time.deltaTime,
                Mathf.Abs(selfOrientationAngle - selfToTargetAngle)
            );
            transform.Rotate(0, 0, turningAngle);
        }
        transform.Translate(Speed * Time.deltaTime * Vector3.up, Space.Self);
    }

    private int GetTurningDirection(float selfToTargetAngle, float selfOrientationAngle)
    {
        return (selfOrientationAngle > selfToTargetAngle) == (
            Mathf.Abs(selfOrientationAngle - selfToTargetAngle) > 180
        ) ? -1 : 1;
    }
}
