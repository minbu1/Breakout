using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Brick : MonoBehaviour
{
    public Sprite[] states;
    public int hits = 2;
    public int points = 100;

    [Header("Audio")]
    public AudioClip breakSound;

    SpriteRenderer sr;
    AudioSource audioSource;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hits--;
        if(hits > 0)
        {
            sr.sprite = states[hits - 1];
        }

        if(hits <= 0)
        {
            GameManager.score += points;
            Destroy(gameObject);

        }
    }
}
