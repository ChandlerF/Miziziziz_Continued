using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed;
    public Rigidbody2D rb;
    Vector2 Movement;
    [SerializeField] TMPro.TextMeshProUGUI DeathText;


    public CameraShake Camera_Shake;
    public bool UnlockedDash = false;
    public bool IsDashing = false;
    public float DashSpeed;
    public float DashDelay;
    public float StartDashDelay;
    public bool StartTheDashDelay = false;

   

    void Update()  //Input
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        if(StartTheDashDelay == true && DashDelay > 0)
        {
            DashDelay -= Time.deltaTime;
        }

        if (UnlockedDash == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(DashDelay <= 0)
            {
                StartCoroutine(Dash(.2f));  //Was .5
            }
        }
    }

    void FixedUpdate()  //Movement (physics)
    {
        if (IsDashing == false)
        {
            rb.MovePosition(rb.position + Movement * MoveSpeed * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyProjectile")
        {
            PlayerDeath();

        }
    }

    public void PlayerDeath()
    {
        Camera_Shake.ShakeCamera();

        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        DeathText.text = "You Died!";
        DeathText.fontSize = 100;
        Time.timeScale = 0f;
    }


    public IEnumerator Dash(float Duration)
    {
        double Elapsed = 0.0f;

        while (Elapsed < Duration)
        {
            IsDashing = true;

            transform.position = Vector2.MoveTowards(transform.position, (rb.position + Movement), DashSpeed * Time.deltaTime);

            Elapsed += .01;

            yield return null;
        }
        DashDelay = StartDashDelay;
        StartTheDashDelay = true;
        IsDashing = false;
    }
}
//        rb.AddForce((rb.position + Movement) * .06f, ForceMode2D.Impulse);
