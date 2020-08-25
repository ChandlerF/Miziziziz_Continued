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

    void Update()
    {
        
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(ScoreM.GetComponent<ScoringManager>().Score > 3)  //Whenever the score hits 4 the difficulty starts increasing
        {
            float NewSpeed = (ScoreM.GetComponent<ScoringManager>().Score / 8) + 5;

            foreach (GameObject Enemy in Enemies)
            {
                Enemy.GetComponent<EnemyMovement2>().Speed = NewSpeed;
                //Debug.Log(Enemy.GetComponent<EnemyMovement2>().Speed);  //Optional
            }
        }
    }
}
