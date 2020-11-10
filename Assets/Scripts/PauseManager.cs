using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Time.timeScale = 1f;
            FindObjectOfType<AudioManager>().Play("Restart");
            SceneManager.LoadScene("Menu");
        }
        
    }
}
