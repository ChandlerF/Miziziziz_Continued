using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PlayerMovement Player;
    public BowController Bow;

    
    public void IncreasePlayerSpeed()
    {
        Player.MoveSpeed += (Player.MoveSpeed / 5f);  //Speed goes from 5 to 6
        CloseUpgradeMenu();
    }

    public void IncreasePlayerFireRate()
    {
        Bow.StartShootDelay -= (Bow.StartShootDelay / 5f);  //Delay between shots goes from .3 to .24
        CloseUpgradeMenu();
    }

    public void UnlockDash()
    {
        Player.UnlockedDash = true;
        CloseUpgradeMenu();
    }

    public void CloseUpgradeMenu()
    {
        gameObject.SetActive(false);
    }
}
