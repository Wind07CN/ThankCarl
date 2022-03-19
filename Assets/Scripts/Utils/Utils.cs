using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{

    /// <summary>
    /// Get playerAttribute
    /// </summary>
    /// <returns></returns>
    public static PlayerAttribute GetPlayerAttribute()
    {
        return GameObject.FindGameObjectWithTag(Constants.PlayerTag).GetComponent<PlayerController>().playerAttribute;
    }

    /// <summary>
    /// Get MainUI Component
    /// </summary>
    /// <returns></returns>
    public static BattleSceneMainUIController GetMainUIController()
    {
        return GameObject.FindGameObjectWithTag(Constants.MainUITag).GetComponent<BattleSceneMainUIController>();
    }

    /// <summary>
    /// Get BattSceneController Component
    /// </summary>
    /// <returns></returns>
    public static BattleSceneController GetMainController()
    {
        return GameObject.FindGameObjectWithTag(Constants.MainControllerTag).GetComponent<BattleSceneController>();
    }

    public static GameObject GetPlayerObject()
    {
        return GameObject.FindGameObjectWithTag(Constants.PlayerTag);
    }

    public static PlayerMoveController GetPlayerMoveController()
    {
        return GameObject.FindGameObjectWithTag(Constants.PlayerTag).GetComponent<PlayerMoveController>();
    }

    public static HitEffectGenerator GetHitEffectGenerator()
    {
        return GameObject.FindGameObjectWithTag(Constants.MainControllerTag).GetComponent<HitEffectGenerator>();
    }

    public static Vector3 GetPlayerPosition()
    {
        return GameObject.FindGameObjectWithTag(Constants.PlayerTag).transform.position;
    }

    public static GameObject GetSpellCasterObject()
    {
        return GameObject.Find("SpellCaster");
    }

    /// <summary>
    /// Find THE Nearest Enemy to the Target
    /// </summary>
    /// <param name="enemiesPos"></param>
    /// <param name="startPos"></param>
    /// <param name="maxDistance"></param>
    /// <returns></returns>
    public static GameObject FindTheNearestEnemy(Vector3 center, float radius, List<GameObject> excludeList = null)
    {
        GameObject nearestEnemy = null;
        float shortestDistance = float.MaxValue;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (!hitCollider.gameObject.CompareTag(Constants.EnemyTag)) continue;
            if (excludeList != null && excludeList.Contains(hitCollider.gameObject)) continue;
            Vector2 distanceVector = hitCollider.gameObject.transform.position - center;
            if (distanceVector.magnitude < shortestDistance)
            {
                shortestDistance = distanceVector.magnitude;
                nearestEnemy = hitCollider.gameObject;
            }
        }
        return nearestEnemy;
    }

    /// <summary>
    /// Get the euler Angle between two points [0, 360)
    /// </summary>
    /// <param name="pos1"></param>
    /// <param name="pos2"></param>
    /// <returns></returns>
    public static float GetTwoPointsEulerAngle(Vector3 pos1, Vector3 pos2)
    {

        float angle = Vector2.Angle(pos2 - pos1, Vector2.up);


        if (pos2.x > pos1.x)
        {
            angle = 360f - angle;
        }

        return angle;
    }


    public static int CalculateGold(int level)
    {
        if (level <= 0)
        {
            return 0;
        }
        return level * 10 + 20;
    }

}
