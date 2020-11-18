using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PlayerMovement Player;
    public BowController Bow;

    public CoinManager Coin;
    public float SpeedIncreaseCost;
    public float FireRateIncreaseCost;
    public float DashCost;


  

    public void IncreasePlayerSpeed()
    {
        if(Coin.CoinScore >= SpeedIncreaseCost)
        {
            Coin.TakeFromCoinScore(SpeedIncreaseCost);
            Player.MoveSpeed += (Player.MoveSpeed / 5f);  //Speed goes from 5 to 6
            CloseUpgradeMenu();
        }
    }

    public void IncreasePlayerFireRate()
    {
        if(Coin.CoinScore >= FireRateIncreaseCost)
        {
            Coin.TakeFromCoinScore(FireRateIncreaseCost);
            Bow.StartShootDelay -= (Bow.StartShootDelay / 5f);  //Delay between shots goes from .3 to .24
            CloseUpgradeMenu();
        }
    }

    public void UnlockDash()
    {
        if(Coin.CoinScore >= DashCost)
        {
            Coin.TakeFromCoinScore(DashCost);
            Player.UnlockedDash = true;
            CloseUpgradeMenu();
        }
    }

    public void CloseUpgradeMenu()
    {
        gameObject.SetActive(false);
    }
}
