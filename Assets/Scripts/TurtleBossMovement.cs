using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBossMovement : MonoBehaviour
{
    private GameObject Player;

    public SpriteRenderer BodyRenderer, HeadRenderer;
    public Vector3 ChargingTarget;
    public float ChargingSpeed;
    public float Speed;
    private bool ChargePosIsSet = false;
    private bool Charge = false;


    public float StartTimerUntilCharge;
    private float TimerUntilCharge;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        TimerUntilCharge = StartTimerUntilCharge;
    }

    // Update is called once per frame

    private void Update()
    {

        if(TimerUntilCharge > 0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
            TimerUntilCharge -= Time.deltaTime;
        }
        else
        {
            Charge = true;
        }







        if(Charge == true)
        {
            if (Vector3.Distance(transform.position, ChargingTarget) > .01f)
            {
                if (ChargePosIsSet == false)
                {
                    ChargingTarget.x = Player.transform.position.x + Random.Range(-5f, 5f);
                    ChargingTarget.y = Player.transform.position.y + Random.Range(-5f, 5f);

                    ChargePosIsSet = true;
                }
                BodyRenderer.color = Color.red;
                HeadRenderer.color = Color.red;

                transform.position = Vector3.MoveTowards(transform.position, ChargingTarget, ChargingSpeed * Time.deltaTime);
            }
            else
            {
                ChargePosIsSet = false;  //Get new coordinates

                BodyRenderer.color = Color.white;  //Make color normal
                HeadRenderer.color = Color.white;  //Make color normal

                TimerUntilCharge = StartTimerUntilCharge;  //Reset Timer
                Charge = false;
            }
        }
    }
}
