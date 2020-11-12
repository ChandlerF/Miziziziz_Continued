using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBossCollision : MonoBehaviour
{

    public FlashWhenDamaged FlashScript;
    public float Health;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(Health);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            Health -= 1;
            FlashScript.Flash();
        }
    }
}
