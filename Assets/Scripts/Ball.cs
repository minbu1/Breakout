using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public float speed = 15;


    [Range(0, 1)]  public float playerInfluence = 0.5f;

    [Header("Audio")]
    public AudioClip hitSound;

    Rigidbody2D rb;
    Rigidbody2D playerRb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(hitSound);

        if(collision.transform.CompareTag("Player"))
        {
            if(playerRb == null)
            {
                playerRb = collision.transform.GetComponent<Rigidbody2D>();
            }

            rb.velocity = new Vector2(playerRb.velocity.x * playerInfluence, rb.velocity.y);
        }
        else if(collision.transform.CompareTag("Ground"))
        {
            GameManager.lives--;
            var player = FindObjectOfType<Player>().transform;
            transform.position = player.position + Vector3.up;
        }
        else
        {
        rb.velocity = new Vector2(Random.Range(-1f, 1f), rb.velocity.y);
        }

    }
}
