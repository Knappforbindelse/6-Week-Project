using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStomp : MonoBehaviour
{
    public playerController playerController;//reference to script of same name
    [SerializeField] GameObject[] waypoint;
    public int damage = 1;

    public float speed;
    public bool horizontal;

    //private bool objectLookingHere = true;
    public Rigidbody2D enemyRb;

    public GameObject Restart;

    void Start()
    {
        Restart.SetActive(false);
    }

    void Update()//in here is for a waypoint system for a 'patroling' enemy
    {

        if(horizontal)//this is used to flip the sprite
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(.5f, .5f);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-.5f, .5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.TakeDamage(damage);
        }
        if(playerController.health <= 0)
        {
            Destroy(gameObject);
            Restart.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("waypoint"))
        {
            if (horizontal)
            {
                horizontal = false;
            }
            else
            {
                horizontal = true;
            }
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
