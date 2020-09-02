using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float time = 1.5f;

    public GameObject[] Enemies;  //An array so you have the option to add more enemies
    public GameObject[] Spawners;  // ^ Same with spawners
    private GameObject CurrentSpawner;
    public int Index;  //For which location to spawn enemy at
    private GameObject Player;
    public float MaxEnemies = 10f;
    public float CurrentEnemies = 1f;

    private void Update()
    {
       Player = GameObject.FindGameObjectWithTag("Player");
    }

    public IEnumerator SpawnAnEnemy()
    {
        if (CurrentEnemies <= MaxEnemies)
        {
            Spawners = GameObject.FindGameObjectsWithTag("Spawner");  //Grabs the Spawners
            Index = Random.Range(0, Spawners.Length);  //Makes an Index that randomly picks a number
            CurrentSpawner = Spawners[Index];  //Makes CurrentSpawner a random Spawner from the array using the Index

            CurrentEnemies++;
            Instantiate(Enemies[Random.Range(0, Enemies.Length)], CurrentSpawner.transform.position, Quaternion.identity);  //Randomly chooses from "Enemies" array and spawns them randomly inside of the circle
            yield return new WaitForSeconds(time);  //Pauses the loop for "time"
            if (Player != null)
            {
                StartCoroutine(SpawnAnEnemy());  //Loops back
            }
        }
    }
}
