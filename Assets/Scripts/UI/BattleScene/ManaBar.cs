using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
	public GameObject PointTextObj;
	public GameObject BarImageObj;
	private PlayerAttribute playerAttribute;
	[HideInInspector] public bool shouldUpdate = true;

	private bool isShaking = false;

	private void Start()
	{
		playerAttribute = GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerAttribute;
	}

	private void Update()
	{
		if (shouldUpdate)
		{
			UpdateBarLength();
			UpdatePointText();
			shouldUpdate = false;
		}
	}

	private void UpdatePointText()
	{
		Text pointText = PointTextObj.GetComponent<Text>();
		pointText.text = (int) playerAttribute.CurrentMana + "/" + (int) playerAttribute.MaxMana;
	}

	private void UpdateBarLength()
	{
		Image image = BarImageObj.GetComponent<Image>();
		image.fillAmount = playerAttribute.CurrentMana / playerAttribute.MaxMana;
	}

	private void StartShake(float dur, float mag)
    {
		if (!isShaking)
        	StartCoroutine(ShakeCoroutine(dur, mag));
    }

	public void Shake()
	{
		StartShake(0.2f, 1.5f);
	}

	public void Shake(float dur, float mag)
	{
		StartShake(dur, mag);
	}

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        Vector3 OriginalPos = transform.position;
        float elapsed = 0.0f;
		isShaking = true;

        while (elapsed < duration)
        {

            float x = Random.Range(-1f, 1f) * magnitude + OriginalPos.x;
            float y = Random.Range(-1f, 1f) * magnitude + OriginalPos.y;

            transform.position = new Vector3(x, y, OriginalPos.z);
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = OriginalPos;
		isShaking = false;
    }
}
