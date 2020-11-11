using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAround : MonoBehaviour
{

    private GameObject Coin;
    public GameObject Player;
    public float Speed;

    private bool FoundCoin = false;

    private void Start()
    {
        Coin = GameObject.FindGameObjectWithTag("Coin");
    }

    private void Update()
    {

        if(Coin == null)
        {
            Coin = GameObject.FindGameObjectWithTag("Coin");
        }


        Vector3 vectorToTarget = Coin.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg -90f;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


























    /*if(Vector2.Distance(Player.transform.position, transform.position) < 1)
    {
        transform.position = Vector2.MoveTowards(transform.position, Coin.transform.position, Speed * Time.deltaTime);
        //transform.rotation = 
    }

    if(Vector2.Distance(Player.transform.position, transform.position) > 1.0001f)
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
    }


     Vector3 vectorToTarget = Coin.transform.position - transform.position;
    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg -90f;
    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * Speed);
    */





    /*public float Radius;
    public float Angle;
    public float Speed;

    private void Update()
    {
        Vector2 Pos = transform.position;
        Pos.x = Mathf.Cos(Angle) * Radius;
        Pos.y = Mathf.Sin(Angle) * Radius;

        Angle += Speed;
        transform.position = Pos;

    }
    */






    /*
    private float RotateSpeed = 5f;
    private float Radius = 0.5f;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }*/
}
