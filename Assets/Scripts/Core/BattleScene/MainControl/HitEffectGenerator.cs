using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject fireHitEffect;
    [SerializeField] private GameObject waterHitEffect;
    [SerializeField] private GameObject earthHitEffect;
    [SerializeField] private GameObject windHitEffect;


    /// <summary>
    /// Generate hit effect at given postion, static related to background
    /// </summary>
    public void InitHitEffect(ElementType elementType, Vector3 position)
    {
        GameObject sprite = MatchSprite(elementType);

        Instantiate(sprite, position, Quaternion.identity);
    }

    /// <summary>
    /// Generate hit effect at given game object, static related to the game object
    /// </summary>
    public void InitHitEffect(ElementType elementType, GameObject parent, Vector3 offset)
    {
        GameObject sprite = MatchSprite(elementType);

        Instantiate(sprite, parent.transform.position + offset, Quaternion.identity, parent.transform);
        SpriteRenderer spriteRenderer = parent.GetComponent<EnemyController>().GetSpriteRenderer();
        StartCoroutine(FlashCoroutine(spriteRenderer));

    }

    private GameObject MatchSprite(ElementType elementType)
    {
        GameObject sprite;
        switch (elementType)
        {
            case ElementType.Fire:
                sprite = fireHitEffect;
                break;
            case ElementType.Water:
                sprite = waterHitEffect;
                break;
            case ElementType.Earth:
                sprite = earthHitEffect;
                break;
            case ElementType.Wind:
                sprite = windHitEffect;
                break;
            default:
                sprite = null;
                break;
        }

        return sprite;
    }

    private IEnumerator FlashCoroutine(SpriteRenderer spriteRenderer, float interval = 0.15f, int times = 1)
    {
        int count = 0;
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
            }
            else
            {
                spriteRenderer.color = new Color(0, 0, 0, 0.5f);
            }
            count++;
            yield return new WaitForSeconds(interval);
        }

        // when enemy object is destroyed because of death
        if (spriteRenderer == null)
            yield return null;

        spriteRenderer.material.shader = originalShader;
        spriteRenderer.color = Color.white;
    }
}
