using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSystem : MonoBehaviour
{
    public int health;
    public int ammOfHeats;

    public Image[] hearts;
    public Sprite HeartFull;
    public Sprite HeartEmpty;

    public void HeartUI()
    {

        if(health > ammOfHeats)
        {
            health = ammOfHeats;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = HeartFull;
            }
            else
            {
                hearts[i].sprite = HeartEmpty;
            }

            if(i < ammOfHeats)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }    
    }
}
