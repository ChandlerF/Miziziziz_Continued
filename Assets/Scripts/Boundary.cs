using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public Transform Player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        Player.position = new Vector2 (0, 0);
    }
}
