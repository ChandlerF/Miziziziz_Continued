using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private CoinManager CoinManagerObject;

   public void Start()
    {

        CoinManagerObject = GameObject.Find("CoinManager").GetComponent <CoinManager> ();
        //CoinManagerObject = GameObject.Find("CoinManager").GetComponent("CoinManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<AudioManager>().Play("CoinPickup");
        CoinManagerObject.AddCoinScore();
        CoinManagerObject.SpawnCoin();
        Destroy(gameObject);
    }
}
