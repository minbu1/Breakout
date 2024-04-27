using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]

public class Brick : MonoBehaviour
{
    public Sprite[] states;
    public int hits = 2;
    public int points = 100;
    public AudioClip breakSound;

    CameraEffects camEffects;
    SpriteRenderer sr;
    AudioSource audioSource;

    private void Start()
    {
        camEffects = Camera.main.gameObject.GetComponent<CameraEffects>();
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();

        var duration = Random.Range(0.1f, 0.3f);
                transform
            .DOScale(Vector2.one, duration)
            .ChangeStartValue(Vector2.zero)
            .SetEase(Ease.OutBounce);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        hits--;
        if(hits > 0)
        {
            sr.sprite = states[hits - 1];
            camEffects.Shake();
        }

        if(hits <= 0)
        {
            GameManager.score += points;

            GetComponent<Collider2D>().enabled = false;
            transform
                .DOMoveY(transform.position.y - 10, 2)
                .SetEase(Ease.OutCubic);
            Destroy(gameObject, 2);
            camEffects.Shake();

            if (audioSource != null && breakSound != null)
            {
                audioSource.PlayOneShot(breakSound);
            }

        }
    }
}
