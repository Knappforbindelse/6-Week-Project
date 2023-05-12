using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BigEggCollect : MonoBehaviour, ICollectible
{
    public GameObject pop;
    public void Collect()
    {
        Destroy(gameObject);
        Debug.Log("BigEgg Collected!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pop.GetComponent<EggPopUp>().Item.SetActive(true);
            pop.GetComponent<EggPopUp>().animator.Play("EggAnim 0");

            
        }
    }
}
