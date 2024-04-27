using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraEffects : MonoBehaviour
{
    public float duration = 0.5f;
    public Vector3 strength = Vector3.one;
    public int vibrato = 10;
    public float randomness = 90;
    public bool snapping = false;
    public bool fadeOut = false;
    public ShakeRandomnessMode mode = ShakeRandomnessMode.Harmonic;

    public GameObject camera;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = camera.transform.position;
    }



    public void Shake()
    {
        transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut, mode)
          .OnComplete(() =>
          {
          transform.DOMove(startPosition, duration).SetEase(Ease.OutQuad);
          });

    }
}
