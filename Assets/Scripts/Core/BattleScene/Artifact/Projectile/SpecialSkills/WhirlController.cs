using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 120f;
    [SerializeField] private float finalScale = 4f;

    [SerializeField] private float expandTime = 2f;
    [SerializeField] private float forceFactor = 40f;
    [SerializeField] private float disappearTIme = 0.3f;

    private float expandSpeed;
    private float disappearSpeed;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        expandSpeed = finalScale / expandTime;
        disappearSpeed = finalScale / disappearTIme;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotateSpeed));
        if (expandTime > 0)
        {
            transform.localScale += Time.deltaTime * Vector3.one * expandSpeed;
            expandTime -= Time.deltaTime;
        }
        else if (expandTime <= 0 && disappearTIme > 0)
        {
            transform.localScale -= Time.deltaTime * Vector3.one * disappearSpeed;
            disappearTIme -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (expandTime > 0)
        {
            if (collision.CompareTag("Enemy"))
            {
                GameObject enemy = collision.gameObject;
                Vector2 force = (enemy.transform.position - transform.position).normalized * forceFactor;
                enemy.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
            }

        }
    }

}
