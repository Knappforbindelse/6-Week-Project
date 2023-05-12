using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public TrailRenderer tr;

    private float horizontal;
    private float moveSpeed = 6f;
    private float jumpHeight = 14f;
    private bool playerLookingHere = true;

    public bool canDash = true;
    private bool isDashing;
    public static bool isGameOver;
    public float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    public int health;
    public int ammOfHearts;//for heart UI
    public int maxHealth = 3;
    public Image[] hearts;//for heart UI
    public Sprite HeartFull;//for heart UI
    public Sprite HeartEmpty;//for heart UI

    DeadZone restart;

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        if(!playerLookingHere && horizontal > 0f)
        {
            Flip();
        }
        else if(playerLookingHere && horizontal < 0f)
        {
            Flip();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        if(health > ammOfHearts)
        {
            health = ammOfHearts;
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

            if(i < ammOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        playerLookingHere = !playerLookingHere;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Get Dashed On" && isDashing)
        {
            collision.gameObject.GetComponent<DashKill>().TakeDamage(1);
        }
    }

    public void TakeDamage(int amount)
    {

        health -= amount;
        if(health <= 0)
        {
            Time.timeScale = 0f;
        }
        if (isDashing)
        {
            health += amount;
        }
    }
}
