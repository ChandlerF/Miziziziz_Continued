using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public string[] Sentences;
    private int Index;
    public float TypingSpeed;  //Lower the speed the faster it types 

    public GameObject ContinueButton;
    public GameObject Grid;
    public GameObject OriginalCamera;


    //Tutorial |
    //         V

    public GameObject Player;
    public GameObject Bow;
    public bool MoveLeft = false;
    public bool MoveRight = false;
    public bool MoveUp = false;
    public bool MoveDown = false;
    public bool Moved = false;
    public bool HasShot = false;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if(TextDisplay.text == Sentences[Index] && Index != 2)
        {
            if(Index != 4)
            {
                ContinueButton.SetActive(true);
            }
        } else if(Index == 2 && Moved == true)
        {
            if (TextDisplay.text == Sentences[Index])
            {
                Index++;
                TextDisplay.text = "";
                StartCoroutine(Type());
            }
        } /*else if(Index == 4 && HasShot == true)
        {
            Index++;
            TextDisplay.text = "";
            StartCoroutine(Type());
        }*/



        //Tutorial |
        //         V
        if (Index == 2)
        {
            Player.SetActive(true);
            Bow.SetActive(false);
            Grid.SetActive(true);
            OriginalCamera.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.A) && Index == 2)
        {
            MoveLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && Index == 2)
        {
            MoveDown = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && Index == 2)
        {
            MoveRight = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && Index == 2)
        {
            MoveUp = true;
        }
        if(MoveUp == true && MoveLeft == true && MoveRight == true && MoveDown == true)
        {
            Moved = true;
        }
        if(Index == 4)
        {
            Bow.SetActive(true);
        }
        if(Index == 4 && Input.GetMouseButtonDown(0))
        {
            if (TextDisplay.text == Sentences[Index])
            {
                HasShot = true;
                Index++;
                TextDisplay.text = "";
                StartCoroutine(Type());
            }
        }
        if(HasShot == true)
        {
            Destroy(Bow, .3f);
        }
        if(Index == 10)
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    IEnumerator Type()
    {
        foreach(char Letter in Sentences[Index].ToCharArray())
        {
            TextDisplay.text += Letter;
            yield return new WaitForSeconds(TypingSpeed);
        }
    }

    public void NextSentence()
    {
        ContinueButton.SetActive(false);

        if(Index < Sentences.Length - 1)
        {
            Index++;
            TextDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            TextDisplay.text = "";
            ContinueButton.SetActive(false);
        }
    }
}
