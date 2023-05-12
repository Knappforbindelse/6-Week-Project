using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stompKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<enemyStomp>();
            enemy.Kill();
        }
    }
}
