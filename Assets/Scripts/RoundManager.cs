using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class RoundManager : MonoBehaviour
{
    public TextMeshProUGUI RoundDisplay;
    public EnemySpawner EnemySpawner;
    public float Round = 0f;
    public float Timer = 5f;  //Between Rounds
    public float CurrentTimer;
    public bool StartTheTimer = false;
    public GameObject ScoreM;
    public float[] PossibleValues = new float[] {10f, 20f, 30f, 40f, 50f, 60f, 70f, 80f, 90f, 100f };
    bool CanStartRound = false;

    void Start()
    {
        Round = 0f;
        RoundStart();
        CurrentTimer = Timer;
    }

    void Update()
    {
        float Score = ScoreM.GetComponent<ScoringManager>().Score;

        if (CurrentTimer >= 0 && StartTheTimer == true)
        {
            CurrentTimer -= Time.deltaTime;
        }

        if (CurrentTimer <= 0 && EnemySpawner.CurrentEnemies == 1f)
        {
            CurrentTimer = Timer;  //Reset Timer
            StartTheTimer = false;
            StartCoroutine(EnemySpawner.SpawnAnEnemy());  //Spawn Enemies
        }

        if (PossibleValues.Contains(Score))  //Bug where if more than 1 Enemy is killed at once then it doesnt register, if... there's more than 10 enemies a round
        {
            if (CanStartRound == true)
            {
                RoundStart();
                CanStartRound = false;
            }
        }
        else
        {
            CanStartRound = true;
        }


}

    public void RoundStart()
    {
        StopCoroutine(EnemySpawner.SpawnAnEnemy());
        EnemySpawner.CurrentEnemies = 1f;
        Round ++;
        DisplayRound();
        StartTheTimer = true;
    }

    void DisplayRound()  //Use Animator to make Machine States
    {
        RoundDisplay.text = ("Round " + Round + "!");  //Need timer so player can read text
        RoundDisplay.GetComponent<Animator>().Play("RoundDisplayBoth");
    }
}
