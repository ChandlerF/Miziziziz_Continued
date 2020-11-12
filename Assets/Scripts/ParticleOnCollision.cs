using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnCollision : MonoBehaviour
{
    public GameObject Particle;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Arrow")
        {
            Instantiate(Particle, collision.transform.position, Quaternion.identity);
        }
    }
}
