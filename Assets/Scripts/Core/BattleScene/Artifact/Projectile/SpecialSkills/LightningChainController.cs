using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightningChainController : MonoBehaviour
{
    public GameObject ZigzagLinePrefab;
    public Color Color;
    [HideInInspector] public float MaxCaptureDistance = 10f;
    public float EffectExistTime = 1f;
    public float EffectDisappearTime = 0.5f;
    public float GaussianRandomDeviation = 0.1f;
	public float LineWidth = 0.2f;
    [HideInInspector] public float Damage = 20f;
    [HideInInspector] public int MaxJumpCount = 3;

    [HideInInspector] public GameObject InitialEnemy;
    [HideInInspector] public ElementType ElementType = ElementType.Wind;
    private float jumpDelay;
    private EnemyPosition currentEnemyPosition;
    private EnemyPosition nextEnemyPosition;
    private float lastJumpTime;
    private int jumpCount = 1;
    private GameObject playerObj;

    private List<ChainSegment> chainSegments = new List<ChainSegment>();
	private List<GameObject> visitedEnemies = new List<GameObject>();

    class ChainSegment
    {
		public ChainSegment(EnemyPosition source, EnemyPosition dest, GameObject line)
		{
			ZigzagLine = line;
			Source = source;
			Destination = dest;
		}
        public GameObject ZigzagLine;
        public EnemyPosition Source;
        public EnemyPosition Destination;
		public void Update()
		{
			Source.Update();
			Destination.Update();
		}
    }

	class EnemyPosition
	{
		public GameObject Enemy;

		private Vector3 position;
		public Vector3 Position
		{
			get
			{
				if (Enemy != null) position = Enemy.transform.position;
				return position;
			}
			private set
			{
				position = value;
			}
		}

		public EnemyPosition(GameObject enemy)
		{
			this.Enemy = enemy;
			Position = enemy.transform.position;
		}

		public void Update()
		{
			if (Enemy != null) position = Enemy.transform.position;
		}

	}

    private void Start()
    {
        jumpDelay = EffectExistTime + EffectDisappearTime;
        currentEnemyPosition = new EnemyPosition(InitialEnemy);
        nextEnemyPosition = new EnemyPosition(InitialEnemy);
        lastJumpTime = Time.time;
		visitedEnemies.Add(InitialEnemy);
        Jump();
        jumpCount++;
    }

    private void Update()
    {
        AttachZigzagLineToEnemy();

        if (Time.time - lastJumpTime > jumpDelay && MaxJumpCount >= jumpCount)
        {
            jumpCount++;
            Jump();
        }
    }

    private void Terminate()
    {
        jumpCount = MaxJumpCount + 1;
        Destroy(gameObject);
    }

    private void Jump()
    {
        lastJumpTime = Time.time;
        currentEnemyPosition = nextEnemyPosition;
        nextEnemyPosition = new EnemyPosition(CaptureNearestEnemy(currentEnemyPosition, MaxCaptureDistance));
        if (nextEnemyPosition == null)
        {
            Terminate();
            return;
        }
		visitedEnemies.Add(nextEnemyPosition.Enemy);
        Utils.GetHitEffectGenerator().InitHitEffect(ElementType, nextEnemyPosition.Enemy, new Vector3(0.5f, 1f, 0));
        DealDamage(nextEnemyPosition.Enemy);
        CreateZigzagLine(currentEnemyPosition, nextEnemyPosition);
    }

    private GameObject CaptureNearestEnemy(EnemyPosition currentEnemyPos, float radius)
    {
        GameObject nearestEnemy = Utils.FindTheNearestEnemy(currentEnemyPos.Position, radius, visitedEnemies);
        return nearestEnemy;
    }

    private void DealDamage(GameObject enemy)
    {
        if (enemy == null || !enemy.CompareTag(Constants.EnemyTag)) return;
        SpellDamageDealer.Deal(ElementType.Wind, enemy, Damage);
    }

    private void CreateZigzagLine(EnemyPosition curEnemyPos, EnemyPosition nextEnemyPos)
    {
        GameObject zigzagLine = Instantiate(ZigzagLinePrefab, curEnemyPos.Position, Quaternion.identity);
        RandomZigzagLineDrawer lineDrawer = zigzagLine.GetComponent<RandomZigzagLineDrawer>();
        lineDrawer.Color = Color;
		lineDrawer.Width = LineWidth;
        lineDrawer.GaussianRandomDeviation = GaussianRandomDeviation;
        lineDrawer.StartPoint = curEnemyPos.Position;
        lineDrawer.EndPoint = nextEnemyPos.Position;

        ChainSegment chainSegment = new ChainSegment(curEnemyPos, nextEnemyPos, zigzagLine);

        Destroy(zigzagLine, EffectExistTime + EffectDisappearTime);
        StartCoroutine(ZigzagLineFadeOutCoroutine(zigzagLine.GetComponent<LineRenderer>()));
        chainSegments.Add(chainSegment);
    }

    private void AttachZigzagLineToEnemy()
    {
        foreach (var chainSegment in chainSegments)
        {
            if (chainSegment.ZigzagLine == null) continue;
            RandomZigzagLineDrawer lineDrawer = chainSegment.ZigzagLine.GetComponent<RandomZigzagLineDrawer>();
            lineDrawer.UpdatePosition(chainSegment.Source.Position, chainSegment.Destination.Position);
        }
    }

    private IEnumerator ZigzagLineFadeOutCoroutine(LineRenderer lineRenderer)
    {
        yield return new WaitForSeconds(EffectExistTime);

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / EffectDisappearTime)
        {
            if (lineRenderer == null) break;
            float alpha = Mathf.Lerp(1, 0, t);
            lineRenderer.startColor = new Color(lineRenderer.startColor.r, lineRenderer.startColor.g, lineRenderer.startColor.b, alpha);
            lineRenderer.endColor = new Color(lineRenderer.endColor.r, lineRenderer.endColor.g, lineRenderer.endColor.b, alpha);
            yield return null;
        }
    }

	private void UpdateEnemyPositions()
	{
		currentEnemyPosition.Update();
		nextEnemyPosition.Update();
		foreach (var chainSegment in chainSegments)
		{
			chainSegment.Update();
		}
	}

}
