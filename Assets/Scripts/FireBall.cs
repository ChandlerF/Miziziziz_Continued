using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float Speed;
    public Transform Player;
    private Vector2 Target;

    public GameObject FireParticles;
    public GameObject SmokeParticles;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        Target = new Vector2(Player.position.x, Player.position.y);


        float angle = Mathf.Atan2(Target.y, Target.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, Speed * Time.deltaTime);  //Change target to Player.Position for Fireball to follow player

        if(transform.position.x == Target.x && transform.position.y == Target.y)
        {
            DestroyFireBall1();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            DestroyFireBall1();
        }
        else
        {
            DestroyFireBall2();
        }
    }


    void DestroyFireBall1()  //Spawns Fire Particles
    {
        FireParticles = Instantiate(FireParticles, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    void DestroyFireBall2()  //Spawns Smoke Particles
    {
        SmokeParticles = Instantiate(SmokeParticles, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

}
