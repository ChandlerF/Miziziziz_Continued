using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public PlayerMovement Player;
    public EnemySpawner Enemy;


    public IEnumerator Shake (float Duration, float Magnitude)
    {
        Vector3 OriginalPos = transform.localPosition;
        double Elapsed = 0.0f;

        while (Elapsed < Duration)
        {
            float X = Random.Range(-1f, 1f) * Magnitude;
            float Y = Random.Range(-1f, 1f) * Magnitude;

            transform.localPosition = new Vector3(X, Y, OriginalPos.z);

            Elapsed += .01;  //Normally its Time.deltaTime, but .01 works and deltaTime doesn't

            //Debug.Log("Duration: " + Duration);
            //Debug.Log("Elapsed: " + Elapsed);


            yield return null;
        }
        transform.localPosition = OriginalPos;
    }

    public void ShakeCamera()
    {
        StartCoroutine(Shake(.10f, .15f));
    }
}
