using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //public EnemyShooting EnemyShoot;
    public GameObject Target;
    public float MoveSpeed;
    public float RotateSpeed;
    private Rigidbody2D rb;
    public float StopDistance;

    public bool Stopped;
    public float FollowDistance;


    void Start()
    {
        Stopped = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Abs(Target.transform.position.x - transform.position.x) >= StopDistance && Mathf.Abs(Target.transform.position.y - transform.position.y) >= StopDistance)  //If X and Y distance between Self and Target is >= StopDistance, go
        {
            Follow();

        }
    }

    public void Follow()
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), RotateSpeed * Time.deltaTime);  //Rotates Player

        transform.position += transform.forward * Time.deltaTime * MoveSpeed;  //Moves Player
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //public EnemyShooting EnemyShoot;
    public GameObject Target;
    public float MoveSpeed;
    public float RotateSpeed;
    private Rigidbody2D rb;
    public float StopDistanceX;
    public float StopDistanceY;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     Follow();   
    }

    public void Follow()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position), RotateSpeed * Time.deltaTime);  //Rotates Player

        transform.position += transform.forward * Time.deltaTime * MoveSpeed;  //Moves Player
    }
}
*/