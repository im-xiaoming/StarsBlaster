using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float sakeMagnitude = 0.5f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        float timeElapsed = 0;
        while (timeElapsed < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * sakeMagnitude;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame(); // wait to the end of the frame
        }

        transform.position = initialPosition;
    }
}
