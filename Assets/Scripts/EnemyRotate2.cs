using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate2 : MonoBehaviour
{

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        Vector3 mousePos = target.transform.position;       //Make it so it rotates towards player

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
