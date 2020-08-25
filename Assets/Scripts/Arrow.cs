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

//Incase the need of a timer before destruction is needed
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Delay;

    // Update is called once per frame
    void Update()
    {
        if(Delay > 0)
        {
            Delay -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)  //Not FindObject Tag because it only hits things on the layer "Collidables"
    {
        if (Delay <= 0)
        {
            Destroy(gameObject);
        }
    }
}
*/