using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakEffect : MonoBehaviour
{
    [SerializeField] public ParticleSystem onBreak = default;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onBreak.Play();
        }
    }
}
