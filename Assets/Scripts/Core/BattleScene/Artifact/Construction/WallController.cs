using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private float expandTime = 0.2f;
    [SerializeField] private float durationTime = 5;
    [SerializeField] private float disapperTime = 0.3f;

    [SerializeField] public float scaleRatio = 1;

    private float expandSpeed;
    private float disapperSpeed;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        expandSpeed = scaleRatio / expandTime;
        disapperSpeed = scaleRatio / disapperTime;
    }

    private void Update()
    {
        UpdateScale();
    }

    private void UpdateScale()
    {
        if (expandTime > 0)
        {
            transform.localScale += expandSpeed * Time.deltaTime * Vector3.one;
            expandTime -= Time.deltaTime;
        }
        else if (durationTime > 0 && expandTime <= 0)
        {
            durationTime -= Time.deltaTime;
        }
        else if (durationTime < 0 && disapperTime > 0)
        {
            transform.localScale -= disapperSpeed * Time.deltaTime * Vector3.one;
            disapperTime -= Time.deltaTime;
        }
        else if (disapperTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
