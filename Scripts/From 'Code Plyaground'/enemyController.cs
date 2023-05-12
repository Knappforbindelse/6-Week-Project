using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public playerController playerController;//reference to the PlayerController script
    public GameObject player;
    public GameObject Restart;
    public float speed;
    public float distanceBetween;
    public int damage = 1;

    private float distance;

    void Start()
    {
        Restart.SetActive(false);
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);//this here used for a more 3D space, the character will flip with movement of player
        }

    }

    public void kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerController.TakeDamage(damage);
            
        }
        if(playerController.health <= 0)
        {
            Destroy(gameObject);
            Restart.SetActive(true);
        }
    }
}
