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
         if(x > RoundIcons.Length)
        {
            for (int i = 0; i < (RoundIcons.Length + 1); i++)
            {
                if(i <= RoundIcons.Length)
                {
                    RoundIcons[i].color = Color.white;
                }
            }
        }
        
        
         if (x < RoundIcons.Length)
         {
          x++;
          RoundIcons[x].color = Color.red;
         }
        
    }
}
