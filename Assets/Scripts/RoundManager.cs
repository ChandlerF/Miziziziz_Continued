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
   // public float[] PossibleValues = new float[] {10f, 20f, 30f, 40f, 50f, 60f, 70f, 80f, 90f, 100f };
    public bool CanStartRound = false;

    //private bool UpgradeAvailable = true;
    public GameObject UpgradeManager;
    public bool SpawnedBoss = false;
    private float EnemiesKilledToSpawn;
    private float EnemiesKilledWhenBossIsSpawned = -1f;
    public RoundDisplayUI RoundUI;

    public CoinManager CoinManager;

    void Start()
    {
        Round = 0f;
        RoundStart(); 
        CurrentTimer = Timer;
        EnemiesKilledToSpawn = EnemySpawner.MaxEnemies * 2f;
    }

    void Update()
    {
        float Score = ScoreM.GetComponent<ScoringManager>().Score;


        /*if(Round % 4 == 0 && UpgradeAvailable == true)
        {
            UpgradeManager.SetActive(true);
            UpgradeAvailable = false;
        }*/


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
       


        if(Score % EnemiesKilledToSpawn == 0 && SpawnedBoss == false)     // if round is a multiple of 2      Round % 2 == 0
        {
            EnemiesKilledWhenBossIsSpawned = Score;
            if (CanStartRound == true)
            {
                Round++;
                DisplayRound();
                EnemySpawner.BossRound();
                CanStartRound = false;
            }
                SpawnedBoss = true;
        }
        else if (Score % 10 == 0)  //If score is a multiple of max enemies (10)         Score % EnemySpawner.MaxEnemies == 0
        {
            if (CanStartRound == true)
            {
                RoundStart();
                CanStartRound = false;
            }
        }
        if (Score % 10 != 0)
        {
            CanStartRound = true;
        }
        if(Score > EnemiesKilledWhenBossIsSpawned)
        {
            SpawnedBoss = false;
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
        RoundUI.NewRound();
        RoundDisplay.text = ("Round " + Round + "!");  //Need timer so player can read text
        RoundDisplay.GetComponent<Animator>().Play("RoundDisplayBoth");
    }

    public void BossDeath()
    {
        CoinManager.GetComponent<CoinManager>().AddCoinScore(5);
        UpgradeManager.SetActive(true);
        RoundStart();
    }
}
