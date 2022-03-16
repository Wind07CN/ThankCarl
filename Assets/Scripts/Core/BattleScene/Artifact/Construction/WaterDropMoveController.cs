
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropMoveController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 30f;

    private GameObject player;

    [SerializeField] private int subSprite = 5;

    [SerializeField] private float expendTime = 0.3f;
    [SerializeField] private float finalScale = 1f;

    private float expendSpeed;

    private void Start()
    {
        player = Utils.GetPlayerObject();
        expendSpeed = finalScale / expendTime;
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (expendTime > 0)
        {
            transform.localScale += expendSpeed * Time.deltaTime * Vector3.one;
            expendTime -= Time.deltaTime;
        }
        if (subSprite == 0)
        {
            Destroy(gameObject);
        }
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position;
    }

    public void DestroySub()
    {
        subSprite--;
    }
}
