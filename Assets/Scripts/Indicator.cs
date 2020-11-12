using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{

    private GameObject Coin;
   

    private void Update()
    {

        if (Coin == null) //Looks for coin if it's null
        {
            Coin = GameObject.FindGameObjectWithTag("Coin");
        }


        Vector3 vectorToTarget = Coin.transform.position - transform.position;  //Rotates-Moves Indicator
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
