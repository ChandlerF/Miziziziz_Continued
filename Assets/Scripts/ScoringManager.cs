﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoringManager : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI ScoreText1;


    public int Score;
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<AudioManager>().Play("Restart");
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        ScoreText1.text = Score.ToString();
    }
}
