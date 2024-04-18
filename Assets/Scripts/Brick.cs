using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Brick : MonoBehaviour
{
    public Sprite[] states;
    public int hits = 2;
    public int points = 100;

    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hits--;
        if(hits <= 0)
        {
            GameManager.score += points;
            Destroy(gameObject);
        }
    }
}
