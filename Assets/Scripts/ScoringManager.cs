using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoringManager : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI ScoreText1;

    public DifficultyManager Difficulty;

    public int Score;
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<AudioManager>().Play("Restart");
            Difficulty.ResetValues();  //Extra precaution towards a bug that saves the prefab's value from the last round (only for the first enemy though)
            SceneManager.LoadScene("Scene1");
            Time.timeScale = 1;
        }

        ScoreText1.text = Score.ToString();
    }
}
