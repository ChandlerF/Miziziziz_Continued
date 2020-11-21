using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class RoundDisplayUI : MonoBehaviour
{
   
    public Image[] RoundIcons;
    public int x;


    private void Start()
    {
        x = 0;
    }

    public void NewRound()
    {   
         if (x <= 9)
         {
          x++;
          RoundIcons[x].color = Color.red;
         }

        if (x >= 10)
        {
            for (int i = 0; i < (x); i++)
            {
                if (i <= RoundIcons.Length)
                {
                    RoundIcons[i].color = Color.white;
                }
            }

            x = 1;
        }

    }
}
