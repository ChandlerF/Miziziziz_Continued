using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidMovement : MonoBehaviour
{
    //Collider Not Working
    //Movement is weird, different from other enemies
    //Look for way to have camera follow player, because enemies look jitterey while moving
    //Implement movement similiar to the wizards but on hit it runs away/runs randomly
    //Double check coinmanager spawning, spawns too close to player
    //Make code for the animals it spawns


    public float Speed;
    private Transform target;
    private GameObject ScoreM;

    private GameObject CoinManager;
    private GameObject RoundManager;
    private CameraShake cameraShake;
    public float Health;
    public FlashWhenDamaged FlashScript;
    private Vector2 RunAwayLocation;

    public bool ChasePlayer;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CoinManager = GameObject.Find("CoinManager");
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        RoundManager = GameObject.Find("Round Manager");
    }


    void Update()
    {
        if(ChasePlayer == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }

        if (Health <= 0)
        {
            //RoundManager.GetComponent<RoundManager>().BossDeath();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            cameraShake.ShakeCamera();
            Health -= 1;
            FlashScript.Flash();
        }
    }

    private void NewRunAwayPosition()
    {
        RunAwayLocation.x = Random.Range(-14f, 14f);
        RunAwayLocation.y = Random.Range(-10f, 10f);
    }
}
