using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public PlayerMovement Player;
    public BowController Bow;

    public CoinManager Coin;
    public float SpeedIncreaseCost;
    public float FireRateIncreaseCost;
    public float DashCost;
    public float CoinIndicatorCost;

                                            //Probably easier to use Scriptable Objects for shop
                                            //Set CoinIndicatorUI to have same position and scale as Dash
                                            //Should probably limit how many times you can upgrade/raise cost for upgrade
    public GameObject PlayerSpeedUI;
    public GameObject FireRateUI;
    public GameObject DashUI;
    public GameObject CoinIndicatorUI;      //Starts off disabled

    public TextMeshProUGUI SpeedCostText;
    public TextMeshProUGUI FireRateCostText;
    public TextMeshProUGUI DashCostText;
    public TextMeshProUGUI CoinIndicatorCostText;



    public GameObject CoinIndicator;

  


    public void UnlockCoinIndicator()
    {
    if(Coin.CoinScore >= CoinIndicatorCost)
     {
      Coin.TakeFromCoinScore(CoinIndicatorCost);
      CoinIndicatorUI.SetActive(false);
      DashUI.SetActive(true);
      CoinIndicator.SetActive(true);
      CloseUpgradeMenu();
     }
    }

    
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
            DashUI.SetActive(false);
            CloseUpgradeMenu();
        }
    }



    public void CloseUpgradeMenu()
    {
        SpeedIncreaseCost += 5;
        CoinIndicatorCost += 5; 
        FireRateIncreaseCost += 5;
        DashCost += 5;

        SpeedCostText.text = SpeedIncreaseCost.ToString();
        FireRateCostText.text = FireRateIncreaseCost.ToString();
        DashCostText.text = DashCost.ToString();
        CoinIndicatorCostText.text = CoinIndicatorCost.ToString();

        gameObject.SetActive(false);
    }

    public void OnlyCloseUpgradeMenu()
    {
        gameObject.SetActive(false);
    }
}
