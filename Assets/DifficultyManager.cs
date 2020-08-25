using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject ScoreM;
    public GameObject[] Enemies;



    void Start()
    {
        ScoreM = GameObject.Find("ScoringManager");
    }

    // Update is called once per frame
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float NewSpeed = ScoreM.GetComponent<ScoringManager>().Score / 15;
       // foreach (Enemy in Enemies)
        //{
           
        //}
    }
}
// = Enemies.GetComponent<EnemyMovement2>().Speed;