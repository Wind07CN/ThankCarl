using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderboltController : MonoBehaviour
{
    public float AreaScale = 2.0f;
    public float Damage = 100.0f;
    public int ZigzagLineNumber = 3;
    public float PrimaryColorLineProportion = 0.75f;
    public Color PrimaryColor = Color.yellow;
    public Color SecondaryColor = Color.gray;
    public GameObject ZigzagLinePrefab;

    private float FlashTime = 0.2f;
    private float ResidenceTime = 0.5f;
    private float DisappearTime = 0.2f;
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    private void Start()
    {
        AddLightningLines();
        SetupAreaEffect();
        StartCoroutine(FlashCoroutine());
        StartCoroutine(FadeOutCoroutine());
        Invoke(nameof(DestroySelf), DisappearTime + ResidenceTime + FlashTime);
    }

    private void SetupAreaEffect()
    {
        ExplosionController explosionController = gameObject.GetComponentInChildren<ExplosionController>();
        explosionController.Scale = AreaScale;
        explosionController.Damage = Damage;
        explosionController.ElementType = ElementType.Wind;
        FlashTime = explosionController.ExpandTime;
        ResidenceTime = explosionController.ResidenceTime;
        DisappearTime = explosionController.DisappearTime;
    }

    private void AddLightningLines()
    {
        Vector3 boltEndPoint = transform.position;
        Vector3 boltStartPoint = boltEndPoint + new Vector3(0, Camera.main.orthographicSize * 2, 0);

        for (int i = 0; i < ZigzagLineNumber; i++)
        {
            GameObject line = Instantiate(ZigzagLinePrefab, transform.position, Quaternion.identity, transform);
            lineRenderers.Add(line.GetComponent<LineRenderer>());
            RandomZigzagLineDrawer lineDrawer = line.GetComponent<RandomZigzagLineDrawer>();
            lineDrawer.StartPoint = boltStartPoint;
            lineDrawer.EndPoint = boltEndPoint;
            lineDrawer.Color = i + 1 > Math.Round((float)ZigzagLineNumber * PrimaryColorLineProportion) ? SecondaryColor : PrimaryColor;
        }
    }

    // Flash of lightning lines and the thunderbolt sprite
    private IEnumerator FlashCoroutine(int times = 2)
    {
        int count = 0;
        float interval = FlashTime / times / 2;

        // the thunderbolt sprite
        SpriteRenderer spriteRenderer = transform.Find("Thunder").GetComponent<SpriteRenderer>();
        // used to render solid color
        Shader solidColorShader = Shader.Find("GUI/Text Shader");
        Shader originalShader = Shader.Find("Sprites/Default");

        spriteRenderer.material.shader = solidColorShader;

        while (count < times * 2)
        {
            // when enemy object is destroyed because of death
            if (spriteRenderer == null)
                break;

            if (count % 2 == 0)
            {
                spriteRenderer.color = Color.white;
                SetLightningLinesColor(Color.white);
            }
            else
            {
                Color darkColor = new Color(0, 0, 0, 0.5f);
                spriteRenderer.color = darkColor;
                SetLightningLinesColor(darkColor);
            }
            count++;
            yield return new WaitForSeconds(interval);
        }

        spriteRenderer.material.shader = originalShader;
        spriteRenderer.color = Color.white;
    }

    // Fade-out of lightning lines and the thunderbolt sprite
    private IEnumerator FadeOutCoroutine()
    {
        yield return new WaitForSeconds(FlashTime + ResidenceTime);

        SpriteRenderer spriteRenderer = transform.Find("Thunder").GetComponent<SpriteRenderer>();

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / DisappearTime)
        {
            spriteRenderer.material.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, t));
            SetLightningLinesColorAlpha(Mathf.Lerp(1, 0, t));
            yield return null;
        }
    }

    private void SetLightningLinesColor(Color color)
    {
        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
        }
    }

    private void SetLightningLinesColorAlpha(float alpha)
    {
        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            lineRenderer.startColor = new Color(lineRenderer.startColor.r, lineRenderer.startColor.g, lineRenderer.startColor.b, alpha);
            lineRenderer.endColor = new Color(lineRenderer.endColor.r, lineRenderer.endColor.g, lineRenderer.endColor.b, alpha);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}