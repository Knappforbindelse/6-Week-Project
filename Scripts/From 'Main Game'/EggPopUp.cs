using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EggPopUp : MonoBehaviour
{
    public Animator animator;
    public GameObject Item;

    void Start()
    {
        Item.SetActive(false);
        animator = GetComponent<Animator>();  
    }
}
