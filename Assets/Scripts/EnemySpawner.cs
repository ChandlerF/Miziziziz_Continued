using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float SpawnRadius = 4, time = 1.5f;

    public GameObject[] Enemies;  //An array so you have the option to add more enemies
    public GameObject[] Spawners;
    private GameObject CurrentSpawner;
    public int Index;
    private GameObject Player;
    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }
    private void Update()
    {
       Player = GameObject.FindGameObjectWithTag("Player");
    }
    IEnumerator SpawnAnEnemy()
    {
        //Vector2 SpawnPos = GameObject.Find("Player").transform.position;  //Grabs the players Position
        // SpawnPos += Random.insideUnitCircle.normalized * SpawnRadius;  //Makes a circle and changes it's size by "SpawnRadius"


        Spawners = GameObject.FindGameObjectsWithTag("Spawner");  //Grabs the Spawners
        Index = Random.Range(0, Spawners.Length);  //Makes an Index that randomly picks a number
        CurrentSpawner = Spawners[Index];  //Makes CurrentSpawner a random Spawner from the array using the Index


        Instantiate(Enemies[Random.Range(0, Enemies.Length)], CurrentSpawner.transform.position, Quaternion.identity);  //Randomly chooses from "Enemies" array and spawns them randomly inside of the circle
        yield return new WaitForSeconds(time);  //Pauses the loop for "time"
        if(Player != null)
        {
            StartCoroutine(SpawnAnEnemy());  //Loops back
        }
    }

}
