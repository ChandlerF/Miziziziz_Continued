using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    public float Speed;
    private Transform target;
    private GameObject ScoreM;

    public GameObject Blood;

    private CameraShake cameraShake;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ScoreM = GameObject.Find("ScoringManager");
        //ScoringManager ScoreM = gameObject.GetComponent<ScoringManager>();
        //ScoreX = ScoreM.GetComponent<ScoringManager>().Score;


    }

    void Awake()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        cameraShake.ShakeCamera();
        ScoreM.GetComponent<ScoringManager>().Score++;
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        Blood = Instantiate(Blood, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
