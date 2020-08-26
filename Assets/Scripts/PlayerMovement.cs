using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed;
    public Rigidbody2D rb;
    Vector2 Movement;
    [SerializeField] TMPro.TextMeshProUGUI ScoreText2;

    void Update()  //Input
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");


    }

    void FixedUpdate()  //Movement (physics)
    {
        rb.MovePosition(rb.position + Movement * MoveSpeed * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log("ah");
        if (col.gameObject.tag == "Enemy")
        {
            // Debug.Log("hi");
            // Destroy(gameObject);
            PlayerDeath();
           
        }
    }

    public void PlayerDeath()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        ScoreText2.text = "You Died!";
        ScoreText2.fontSize = 100;
        Time.timeScale = 0;
    }
}
