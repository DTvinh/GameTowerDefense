using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    // public bool canShake = false;
    // public AnimationCurve curve;

    // public float duration = 1f;

    private float shakeDuration = 0.3f; // Ensure this starts at 0

    public float shakeMagnitude = 0.5f;

    public float dampingSpeed = 1f;



    private Vector3 originalPosition;

    void Start()
    {
        Observer.AddListener(CONSTANT.CAMERA_SHAHKE, EffectShake);
    }


    void Update()
    {
        // if (canShake)
        // {
        //     canShake = false;
        //     StartCoroutine(Shaking());
        // }
    }


    public void EffectShake(object[] datas)
    {
        // StartCoroutine(Shaking());
        originalPosition = transform.position;

        transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;

        // Decrease shake duration

        shakeDuration -= Time.deltaTime * dampingSpeed;

        // Reset position when duration ends

        if (shakeDuration <= 0)

        {
            shakeDuration = 0f;

            transform.position = originalPosition;

        }
    }





    // IEnumerator Shaking()
    // {
    //     Vector3 startPosition = transform.position;

    //     float elapsedTime = 0f;

    //     while (elapsedTime < duration)
    //     {
    //         elapsedTime += Time.deltaTime;
    //         float strength = curve.Evaluate(elapsedTime / duration);
    //         transform.position = startPosition + Random.insideUnitSphere;
    //         yield return null;

    //     }

    //     transform.position = startPosition;

    // }
}
