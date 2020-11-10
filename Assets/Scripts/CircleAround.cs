using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAround : MonoBehaviour
{

    public GameObject Coin;
    public GameObject Player;
    public float Speed;

    private void Update()
    {

        if(Vector2.Distance(Player.transform.position, transform.position) < 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, Coin.transform.position, Speed * Time.deltaTime);
            //transform.rotation = 
        }

        if(Vector2.Distance(Player.transform.position, transform.position) > 2.0001f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
        }
    }





















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
