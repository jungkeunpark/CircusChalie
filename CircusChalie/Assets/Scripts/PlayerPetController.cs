using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerPetController : MonoBehaviour
{
    
    public float petjumpForce = 300f;
    public GameObject playerpet = default;
   
    private int petjumpCount = 0;
    private bool petisGrounded = false;
    private bool petisLeft = false;
    private bool petisRight = false;

    public float speed = default;
    public float petmovespeed = 5f;

    private Rigidbody2D playerPetRigid = default;
    private Animator petanimator = default;



    void Start()
    {
        playerPetRigid = GetComponent<Rigidbody2D>();
        petanimator = GetComponent<Animator>();
        

        GFunc.Assert(playerPetRigid != null);
        GFunc.Assert(petanimator != null);
        
    }


    void Update()
    {
        Jump();
        petanimator.SetBool("Ground", petisGrounded);
        petanimator.SetBool("Left", petisLeft);
        petanimator.SetBool("Right", petisRight);
        float pethorizontalInput = Input.GetAxis("Horizontal");
        float petmovement = pethorizontalInput * petmovespeed * Time.deltaTime;

        transform.Translate(Vector3.right * petmovement);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
            petisLeft = true;
            petisRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            petisRight = true;
            petisLeft = false;
        }


    }

    
    public void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Z) && petjumpCount < 2)
        {
            petjumpCount++;
            playerPetRigid.velocity = Vector2.zero;
            playerPetRigid.AddForce(new Vector2(0, petjumpForce));
            

        }
        else if (Input.GetKeyDown(KeyCode.Z) && 0 < playerPetRigid.velocity.y)
        {
            playerPetRigid.velocity = playerPetRigid.velocity * 0.5f;
        }
    }






    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            petisGrounded = true;
            petjumpCount = 0;
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        petisGrounded = false;
    }




}
