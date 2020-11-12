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
        if(Health <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Health -= 1;
            FlashScript.Flash();
        }
    }
}
