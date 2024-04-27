using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed = 5;
    public Sprite blinkingSprite; // Assign the blinking sprite in the Unity Editor
    public float blinkInterval = 0.5f;

    private Rigidbody2D rb;
    private float horizontal;
    private bool isBlinking = false;
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(BlinkPlayer());
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, 0);
    }

    IEnumerator BlinkPlayer()
    {
        isBlinking = true;
        while (isBlinking)
        {
            // Toggle between the original sprite and the blinking sprite
            spriteRenderer.sprite = (spriteRenderer.sprite == originalSprite) ? blinkingSprite : originalSprite;
            yield return new WaitForSeconds(blinkInterval);
        }
        // Ensure the original sprite is restored when blinking stops
        spriteRenderer.sprite = originalSprite;
        isBlinking = false;
    }
}
