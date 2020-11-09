using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject ScoreM;  //ScoreM = ScoringManager
    public GameObject[] Enemies;

    public EnemyMovement2 EnemyScript;
    public Wizard WizardScript;


    //The bigger the numbers the easier the enemies

    [Range(15f, 25f)]
    public float KnightSpeedCurve;

    [Range(35f, 45f)]
    public float WizardFireRateCurve;

    [Range(25f, 35f)]
    public float WizardSpeedCurve;

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
            float KnightNewSpeed = 4 + (Score / KnightSpeedCurve);
            float NewFireRate = 3 - (Score / WizardFireRateCurve);
            float WizardNewSpeed = 4 + (Score / WizardSpeedCurve);

            foreach (GameObject Enemy in Enemies)
            {
                EnemyScript.Speed = KnightNewSpeed;

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
