using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public float ArrowSpeed;

    public float StartShootDelay;
    private float ShootDelay;


    private void Start()
    {
        ShootDelay = StartShootDelay;
    }


    void Update()
    {
        if(ShootDelay > 0f)  //Timer between shots
        {
            ShootDelay -= Time.deltaTime;
        }

        AimAndShoot();
    }


    private void AimAndShoot()
    {

        if (ShootDelay <= 0 && Input.GetMouseButtonDown(0))
            {
            Vector3 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //Gets Cursor
            Vector2 ShootingDirection = cursorInWorldPos - transform.position;   //Gets Direction by Target-MyPosition


            ShootingDirection.Normalize();

            FindObjectOfType<AudioManager>().Play("ShootBow");

            GameObject Arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity); //Spawn Arrow
            Arrow.GetComponent<Rigidbody2D>().velocity = ShootingDirection * ArrowSpeed; //Set Rigidbody Velocity (<- Vector2) to Shooting Direction(Vector2) * ArrowSpeed (float)
            Arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(ShootingDirection.y, ShootingDirection.x) * Mathf.Rad2Deg - 45f); //X and Y values are flipped because of Mathf.Atan2 --- -45f is to counter the sprite's defualt rotation
            Destroy(Arrow, 2.0f);

            ShootDelay = StartShootDelay;
            }
        
        
        
    }
}