using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject ScoreM;  //ScoreM = ScoringManager
    public GameObject[] Enemies;

    public EnemyMovement2 EnemyScript;
    public Wizard WizardScript;


    private void Awake()
    {
        ResetValues();
    }

    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float Score = ScoreM.GetComponent<ScoringManager>().Score;

        if (Score > 3)  //Whenever the score hits 4 the difficulty starts increasing
        {
            float EnemyNewSpeed = 4 + (Score / 10);
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

    public void ResetValues()  //Sets the prefabs values since after the if(Score > 3) statement changes it
    {
        EnemyScript.Speed = 4;

        WizardScript.StartFireRate = 3;
        WizardScript.Speed = 4;
    }
}
