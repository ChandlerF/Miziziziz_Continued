using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCast : MonoBehaviour
{



    public GameObject Target;
    void Start()
    {
        SaveNewCoin();
    }

    void Update()
    {
        SaveNewCoin();
        Physics2D.Linecast(transform.position, Target.transform.position);
        if (Physics.Linecast(transform.position, Target.transform.position))
        {
            Debug.Log("Hit");
        }
    }

    public void SaveNewCoin()
    {
        Target = GameObject.FindGameObjectWithTag("Coin");
        Debug.Log("Found Coin!");
    }
}
