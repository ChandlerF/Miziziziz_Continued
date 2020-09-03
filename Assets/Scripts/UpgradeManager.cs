using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PlayerMovement Player;
    public BowController Bow;

    void Start()
    {

    }

    void Update()
    {

    }

    public void IncreasePlayerSpeed()
    {
        Player.MoveSpeed += (Player.MoveSpeed / 5f);  //Speed goes from 5 to 6
    }

    public void IncreasePlayerFireRate()
    {
        Bow.ShootDelay -= (Bow.ShootDelay / 5f);  //Delay between shots goes from .3 to .24
    }

    public void UnlockDash()
    {
        Player.UnlockedDash = true;
    }
}
