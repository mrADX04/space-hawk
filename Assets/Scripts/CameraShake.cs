using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude= 0.5f;
    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            //Here (Vector3) is used to ask Unity to treat any object that is Vector2 as a Vector3 where z is 0 
            //Here insideUnitCircle is vector2 so we used (Vector3) as our transform of camera is vector3
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime = elapsedTime + Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;


    }
}
