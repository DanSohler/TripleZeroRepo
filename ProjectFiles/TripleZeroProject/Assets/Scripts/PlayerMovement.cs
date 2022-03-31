using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    //getting key binds

    //forward key
    [SerializeField]
    KeyCode forward = KeyCode.D;
    //backwards key
    [SerializeField]
    KeyCode backwards = KeyCode.A;
    //jump key
    [SerializeField]
    KeyCode jump = KeyCode.W;
    //wall climb key
    [SerializeField]
    KeyCode wallGrab = KeyCode.Space;
   

    //--------------------------------------------------------------------------------------------------------------------------

    //reference to rigidbody
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed;
    //distance of raycast
    [SerializeField]
    private float groundDist;
    //seting the height of the jump
    [SerializeField]
    private float jumpHeight = 1600;
    //setting the maximum speed of any character
    [SerializeField]
    private float maxSpeed = 40f;

    //--------------------------------------------------------------------------------------------------------------------------
    //makes sure that jump hight can't be highter then set by preventing player from jumping once a frame
    private bool jumped;
    private float jumpTimer;

    //is player in the air?
    private bool inAir;
    //is player looking to the right?
    public bool lookingRight = true;

    //--------------------------------------------------------------------------------------------------------------------------

    void Update()
    {
        //run keyPressed
        keyPressed();

        //--------------------------------------------------------------------------------------------------------------------------

        //prevents player from jumping once a frame
        if (jumpTimer <= 0)
        {
            jumped = false;
        }
        else
        {
            jumpTimer -= Time.deltaTime;
        } 

        //--------------------------------------------------------------------------------------------------------------------------

        // Limiting Speed, slows you down more if your in the air/ wall running

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        gravity(2);

        //Debug.Log(jumped);
        //Debug.Log(jumpTimer);
    }

    //--------------------------------------------------------------------------------------------------------------------------

    //keyPressed
    void keyPressed()
    {
        //--------------------------------------------------------------------------------------------------------------------------

        //if pressing forward key
        if (Input.GetKey(forward))
        {

            //set direction player is looking towards to the right of the screen
            if (lookingRight == false)
            {
                lookingRight = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            //makes character move
            rb.AddForce(transform.forward * moveSpeed * Time.deltaTime);
        }

        //--------------------------------------------------------------------------------------------------------------------------

        //if pressing backwards key
        if (Input.GetKey(backwards))
        {
            //set direction player is looking towards to the left of the screen
            if (lookingRight == true)
            {
                lookingRight = false;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            //makes character move
            rb.AddForce(transform.forward * moveSpeed * Time.deltaTime);
        }

       
        //--------------------------------------------------------------------------------------------------------------------------

        //stores raycast hit data in 'floor'
        RaycastHit floor;

        //if pressing jump key
        if (Input.GetKey(jump))
        { 
            //run raycast to check for ground

            if (Physics.Raycast(rb.transform.position, Vector3.down, out floor, groundDist))
            {
                if (floor.transform.tag == "Floor" || floor.transform.tag == "Wall")
                {
                    if (jumped == false)
                    {
                        //jumps

                        rb.AddForce(Vector3.up * jumpHeight);

                        jumped = true;
                        jumpTimer = 1;
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------

        if (Physics.Raycast(rb.transform.position, Vector3.down, out floor, groundDist))
        {
            inAir = false;
        }
        else
        {
            gravity(1.2f);
            inAir = true;
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------

    private void gravity(float multiplier)
    {
        rb.AddForce(-transform.up * 9.807f * Time.deltaTime * multiplier, ForceMode.Impulse);
    }

    //--------------------------------------------------------------------------------------------------------------------------

}
