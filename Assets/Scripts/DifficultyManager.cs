using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject ScoreM;  //ScoreM = ScoringManager
    public GameObject[] Enemies;

    public EnemyMovement2 EnemyScript;
    public Wizard WizardScript;



    void Start()  //Sets the prefabs values since after the if(Score > 3) statement changes it
    {
        EnemyScript.Speed = 5;

        WizardScript.StartFireRate = 3;
        WizardScript.Speed = 4;
    }
    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float Score = ScoreM.GetComponent<ScoringManager>().Score;

        if (Score > 3)  //Whenever the score hits 4 the difficulty starts increasing
        {
            float EnemyNewSpeed = 5 + (Score / 8);
            float NewFireRate = 3 - (Score / 25);
            float WizardNewSpeed = 4 + (Score / 12);

            foreach (GameObject Enemy in Enemies)
            {
                EnemyScript.Speed = EnemyNewSpeed;

                WizardScript.StartFireRate = NewFireRate;
                WizardScript.Speed = WizardNewSpeed;
            }
        }
    }
}
