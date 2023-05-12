using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorA : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)//This is for collecting "Egg Shell"
    {
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if(collectible != null)
        {
            collectible.Collect();
        }
    }
}
