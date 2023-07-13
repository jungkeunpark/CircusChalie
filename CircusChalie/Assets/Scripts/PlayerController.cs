using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public AudioClip backstep;
    public float jumpForce = 300f;
    public GameObject player = default;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isLeft = false;
    private bool isRight = false;
    private bool isLife = false;

    private bool isDead = false;
    public float speed = default;
    public float movespeed = 5f;
    public Animator Life1 = default;
    public Animator Life2 = default;
    public Animator Life3 = default;

    private Rigidbody2D playerRigid = default;
    private Animator animator = default;
    private AudioSource playerAudio = default;
    


    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        GFunc.Assert(playerRigid != null);
        GFunc.Assert(animator != null);
        GFunc.Assert(playerAudio != null);
    }


    void Update()
    {



        if (isDead) { return; }


        //if (Input.GetKeyDown(KeyCode.Z) && jumpCount < 2)
        //{
        //    jumpCount++;
        //    playerRigid.velocity = Vector2.zero;
        //    playerRigid.AddForce(new Vector2(0, jumpForce));
        //    playerAudio.Play();
        //}
        //else if (Input.GetKeyDown(KeyCode.Z) && 0 < playerRigid.velocity.y)
        //{
        //    playerRigid.velocity = playerRigid.velocity * 0.5f;
        //}

        Jump();
        animator.SetBool("Ground", isGrounded);
        animator.SetBool("Left", isLeft);
        animator.SetBool("Right", isRight);
        float horizontalInput = Input.GetAxis("Horizontal");
        float movement = horizontalInput * movespeed * Time.deltaTime;

        transform.Translate(Vector3.right * movement);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isLeft = true;
            isRight = false;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            isRight = true;
            isLeft = false;
        }
            

    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && jumpCount < 2)
        {
            jumpCount++;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Z) && 0 < playerRigid.velocity.y)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }
    }
    public void Backstep()
    {
        
            animator.SetTrigger("Left");
            playerAudio.clip = backstep;
            playerAudio.Play();
        
    }


    private void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;
        GameManager.instance.onPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag.Equals("Death") && isDead == false)
        {
            if (Life3.GetBool("Life") == true && Life2.GetBool("Life") == true && Life1.GetBool("Life") == true)
            {
                Life3.SetBool("Life", isLife);
            }
            else if (Life3.GetBool("Life") == false && Life2.GetBool("Life") == true && Life1.GetBool("Life") == true)
            {
                Life2.SetBool("Life", isLife);
            }
            else if (Life3.GetBool("Life") == false && Life2.GetBool("Life") == false && Life1.GetBool("Life") == true)
            {
                Life1.SetBool("Life", isLife);
            }
            else if (Life3.GetBool("Life") == false && Life2.GetBool("Life") == false && Life1.GetBool("Life") == false)
            {
                animator.SetTrigger("Die");
                playerAudio.clip = deathClip;
                playerAudio.Play();
                playerRigid.velocity = Vector2.zero;
                isDead = true;
                GameManager.instance.onPlayerDead();
            }
        }
        if (collision.tag.Equals("Score"))
        {

            GameManager.instance.AddScore(1);
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void moving()
    {

    }


}
