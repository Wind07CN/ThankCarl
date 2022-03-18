using UnityEngine;

public class RandomZigzagLineDrawer : MonoBehaviour
{

    public Color Color = Color.white;
    public float Width = 0.2f;
    public Vector3 StartPoint = Vector3.zero;
    public Vector3 EndPoint = Vector3.zero;
    public int SegmentCount = 10;
    public float GaussianRandomDeviation = 0.3f;

    void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = SegmentCount + 1;
        lineRenderer.SetPosition(0, StartPoint);
        lineRenderer.SetPosition(SegmentCount, EndPoint);
        lineRenderer.startColor = Color;
        lineRenderer.endColor = Color;
        lineRenderer.startWidth = Width;
        lineRenderer.endWidth = Width;

        // determine intermediate points
        float unifiedDeltaX = (EndPoint.x - StartPoint.x) / SegmentCount;
        float unifiedDeltaY = (EndPoint.y - StartPoint.y) / SegmentCount;
        for (int i = 1; i < SegmentCount; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(
                StartPoint.x + unifiedDeltaX * i + GaussianRandomDeviation * GaussianRandom(),
                StartPoint.y + unifiedDeltaY * i + GaussianRandomDeviation * GaussianRandom(),
                StartPoint.z
            ));
        }
    }

    private float GaussianRandom()
    {
        float u1 = Random.Range(0.0f, 1.0f);
        float u2 = Random.Range(0.0f, 1.0f);
        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);
        return randStdNormal;
    }

}