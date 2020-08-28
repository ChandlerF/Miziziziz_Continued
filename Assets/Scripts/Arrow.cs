using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)    //Not FindObject Tag because it only hits things on the layer "Collidables"
    {
        Destroy(gameObject);  
    }
}
