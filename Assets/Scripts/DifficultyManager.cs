using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject ScoreM;
    public GameObject[] Enemies;



    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(ScoreM.GetComponent<ScoringManager>().Score > 3)  //Whenever the score hits 4 the difficulty starts increasing
        {
            float Score = ScoreM.GetComponent<ScoringManager>().Score;
            float NewSpeed = Score / 8 + 5;
            float NewFireRate = 3 - (Score / 25);

            foreach (GameObject Enemy in Enemies)
            {
                //Enemy.GetComponent<EnemyMovement2>().Speed = NewSpeed;
                Enemy.GetComponent<Wizard>().StartFireRate = NewFireRate;
                //Debug.Log(GetComponent<Wizard>().StartFireRate);  //Optional
                //Debug.Log("Ah");
            }
        }
    }
}
