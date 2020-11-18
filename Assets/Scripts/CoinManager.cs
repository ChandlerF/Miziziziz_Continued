using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public GameObject Player;

    public GameObject PrefabCoin;
    private Vector2 SpawnLocation;

    [SerializeField] TMPro.TextMeshProUGUI CoinScoreText;
    public float CoinScore = 0f;

    private bool FirstCoinSpawned = false;
    private GameObject Coin;

    public float DistanceAwayFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCoin();
        Coin = GameObject.FindGameObjectWithTag("Coin");
    }


    public void SpawnCoin()
    {
        SpawnLocation.x = Random.Range(-14f, 14f);
        SpawnLocation.y = Random.Range(-10f, 10f);

        if(Vector2.Distance(Player.transform.position,  SpawnLocation) > DistanceAwayFromPlayer)
        {
            if(FirstCoinSpawned == false)
            {
                Instantiate(PrefabCoin, SpawnLocation, Quaternion.identity);
                FirstCoinSpawned = true;
            }
            else
            {
                Coin.transform.position = SpawnLocation;
            }
        }
        else
        {
            SpawnCoin();
        }
    }

    public void AddCoinScore(int x)
    {
        CoinScore += x;
        CoinScoreText.text = CoinScore.ToString();
    }

    public void TakeFromCoinScore(float x)
    {
        CoinScore -= x;
        CoinScoreText.text = CoinScore.ToString();
    }
}
