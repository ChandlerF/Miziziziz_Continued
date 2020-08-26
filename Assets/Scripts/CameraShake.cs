using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake (float Duration, float Magnitude)
    {
        Vector3 OriginalPos = transform.localPosition;

        float Elapsed = 0.0f;

        if (Elapsed < Duration)
        {
            float X = Random.Range(-1f, 1f) * Magnitude;
            float Y = Random.Range(-1f, 1f) * Magnitude;

            transform.localPosition = new Vector3(X, Y, OriginalPos.z);

            Elapsed += Time.deltaTime;

            Debug.Log("Duration: " + Duration);
            Debug.Log("Elapsed: " + Elapsed);


            yield return null;
        }
        transform.localPosition = OriginalPos;
    }
}
