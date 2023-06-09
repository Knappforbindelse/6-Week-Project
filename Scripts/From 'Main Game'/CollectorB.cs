using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorB : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//This is for collecting "Egg"
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if(collectible != null)
        {
            collectible.Collect();
        }
    }
}
