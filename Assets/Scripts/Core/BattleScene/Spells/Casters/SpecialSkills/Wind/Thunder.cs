using UnityEngine;

public class Thunder : AbstractSpellCaster
{
    public int ThunderboltNumber = 5;
    public GameObject ThunderboltPrefab;
    
    public override void Cast(ISpell spell)
    {
        Vector3[] hitPoints = DecideHitPoints();
        foreach (Vector3 hitPoint in hitPoints)
        {
            Instantiate(ThunderboltPrefab, hitPoint, Quaternion.identity);
        }
    }

    public Vector3[] DecideHitPoints()
    {
        Vector3[] points = new Vector3[ThunderboltNumber];
        for (int i = 0; i < ThunderboltNumber; i++)
        {
            points[i] = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), 1));
        }
        return points;
    }

}