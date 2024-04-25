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


    private void Start()
    {
        float startPosX = camera.transform.position.x;
        float startPosY = camera.transform.position.y;
        float startPosZ = camera.transform.position.z;
    }



    public void Shake()
    {
        transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut, mode);
        
    }
}
