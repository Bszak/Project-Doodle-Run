using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jump;
    private Rigidbody2D rb;
    private bool isGrounded;
    public float jumpForce = 10f;
    public float jumpCooldown = 0.5f;
    private float lastJumpTime;
    public float increasedGravityScale = 2f;

    private Animator anim;

    private void start()
    {
        anim = GetComponent<Animator>();

    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    /*{
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
        }  
    }*/
    //Improved code to allow for double jumping. Plus, its just more fun.
    {
        if (Time.time - lastJumpTime > jumpCooldown)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                lastJumpTime = Time.time;
            }
        }
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = increasedGravityScale;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }*/

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0);
            //Change this to a game over scene later
        }
    }
    

     
    



}
