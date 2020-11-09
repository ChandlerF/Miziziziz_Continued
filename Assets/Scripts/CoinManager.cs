using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public GameObject Player;

    public GameObject Coin;
    private Vector2 SpawnLocation;

    [SerializeField] TMPro.TextMeshProUGUI CoinScoreText;
    private float CoinScore = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCoin()
    {
        SpawnLocation.x = Random.Range(-14f, 14f);
        SpawnLocation.y = Random.Range(-10f, 10f);

        if(Vector2.Distance(Player.transform.position,  SpawnLocation) > 5)
        {
            Instantiate(Coin, SpawnLocation, Quaternion.identity);
        }
        else
        {
            SpawnCoin();
        }
    }

    public void AddCoinScore()
    {
        CoinScore += 1;
        CoinScoreText.text = CoinScore.ToString();
    }
}
