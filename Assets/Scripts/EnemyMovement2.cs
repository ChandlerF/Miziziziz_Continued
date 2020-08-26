using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    public float Speed;
    private Transform target;
    public GameObject ScoreM;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ScoreM = GameObject.Find("ScoringManager");
        //ScoringManager ScoreM = gameObject.GetComponent<ScoringManager>();
         //ScoreX = ScoreM.GetComponent<ScoringManager>().Score;

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("ah");
        if (col.gameObject.tag == "Arrow")
        {
            // Debug.Log("hi");
            ScoreM.GetComponent<ScoringManager>().Score++;
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            Destroy(gameObject);
        }
    }
}
