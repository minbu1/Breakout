using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public float speed = 15;


    [Range(0, 1)]  public float playerInfluence = 0.5f;

    Rigidbody2D rb;
    Rigidbody2D playerRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if(playerRb == null)
            {
                playerRb = collision.transform.GetComponent<Rigidbody2D>();
            }

            rb.velocity = new Vector2(playerRb.velocity.x * playerInfluence, rb.velocity.y);
        }
        else
        {
        rb.velocity = new Vector2(Random.Range(-1f, 1f), rb.velocity.y);
        }


    }
}
