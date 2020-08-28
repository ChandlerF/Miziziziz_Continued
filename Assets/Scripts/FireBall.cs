using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float Speed;
    public Transform Player;
    private Vector2 Target;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        Target = new Vector2(Player.position.x, Player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, Speed * Time.deltaTime);  //Change target to Player.Position for Fireball to follow player

        if(transform.position.x == Target.x && transform.position.y == Target.y)
        {
            DestroyFireBall();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.CompareTag("Player"))
        //{
            DestroyFireBall();
        //}
        
    }


    void DestroyFireBall()
    {
        Destroy(gameObject);
    }

}
