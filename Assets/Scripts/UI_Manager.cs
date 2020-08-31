using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Restart");
        SceneManager.LoadScene("Scene1");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
