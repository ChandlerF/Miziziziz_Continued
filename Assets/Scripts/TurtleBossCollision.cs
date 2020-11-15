using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBossCollision : MonoBehaviour
{

    public FlashWhenDamaged FlashScript;
    public float Health;
    public GameObject Turtle;
    //private GameObject ScoreM;
    private GameObject CoinManager;
    private CameraShake cameraShake;
    public Animator anim;

    private GameObject RoundManager;

    void Start()
    {
        //ScoreM = GameObject.Find("ScoringManager");
        CoinManager = GameObject.Find("CoinManager");
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        RoundManager = GameObject.Find("Round Manager");
    }

    void Update()
    {
        if(Health <= 0)
        {
            //ScoreM.GetComponent<ScoringManager>().Score += 1;
            CoinManager.GetComponent<CoinManager>().AddCoinScore(5);
            RoundManager.GetComponent<RoundManager>().BeatBoss = true;
            RoundManager.GetComponent<RoundManager>().CanStartRound = true;
            Destroy(Turtle);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            cameraShake.ShakeCamera();
            Health -= 1;
            FlashScript.Flash();
            anim.Play("TurtleBossRotate");
        }
    }
}
