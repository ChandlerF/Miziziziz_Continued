using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public float Speed;
    public float StoppingDistance;  //Distance to stop away from player
    public float RetreatDistance;

    public Transform Player;

    public float FireRate;
    public float StartFireRate;

    public GameObject Fireball;

    public EnemyMovement2 Enemy;
    public GameObject ScoreM;

    public GameObject Blood;

    public CameraShake cameraShake;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        FireRate = StartFireRate;

        ScoreM = GameObject.Find("ScoringManager");
    }

    void Awake()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, Player.position) > StoppingDistance)  //If enemy is too far away
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);  //Move closer

        } else if (Vector2.Distance(transform.position, Player.position) < StoppingDistance && (Vector2.Distance(transform.position, Player.position) > RetreatDistance))  //But if enemy is close, but not too close
        {
            transform.position = this.transform.position;  //Stop moving
        }else if (Vector2.Distance(transform.position, Player.position) < RetreatDistance)  //If enemy is too close
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, -Speed * Time.deltaTime);  //Move away
        }


        if(FireRate <= 0 && Vector2.Distance(transform.position, Player.position) < StoppingDistance && (Vector2.Distance(transform.position, Player.position) > RetreatDistance))
        {
            Instantiate(Fireball, transform.position, Quaternion.identity);
            FireRate = StartFireRate;
        }
        else
        {
            FireRate -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            WizardDeath();

        }
    }

    void WizardDeath()  //Smarter to call that function but didnt work 1st time
    {
        cameraShake.ShakeCamera();
        ScoreM.GetComponent<ScoringManager>().Score++;
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        Blood = Instantiate(Blood, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}


