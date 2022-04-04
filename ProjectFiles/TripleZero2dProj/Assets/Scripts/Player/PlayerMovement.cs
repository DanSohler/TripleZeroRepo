using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //calling custom character controller
    [SerializeField]
    private CharacterController2D cc;
    //--------------------------------------------------------------------------------------------------------------------------

    //forward key
    [SerializeField]
    KeyCode forward = KeyCode.D;
    //backwards key
    [SerializeField]
    KeyCode backwards = KeyCode.A;
    //jump key
    [SerializeField]
    KeyCode jump = KeyCode.W;
    //interact key
    [SerializeField]
    KeyCode interact = KeyCode.E;
    //--------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    private float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jumping = false;

    //--------------------------------------------------------------------------------------------------------------------------
    //interact systems

    public bool canInteract = true;
    public GameObject interactObject = null;
    private List<string> Clothes;

    private void Start()
    {
        Clothes = new List<string>(capacity:2);
        Clothes.Add("DapperCapper");
        Clothes.Add("Null");
    }

    //--------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        /**
        for (int i = 0; i < Clothes.Count; i++)
        {
            Debug.Log(message: i + " " + Clothes[i]);
        }
        **/


        //Debug.Log(canInteract + " " + interactObject);

        //setting movement values
        if (Input.GetKey(forward))
        {  
            horizontalMove = 1 * runSpeed;
        }  
        else if (Input.GetKey(backwards))
        {
            horizontalMove = -1 * runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
        //--------------------------------------------------------------------------------------------------------------------------

        //allowing jump
        if (Input.GetKey(jump))
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }
        //--------------------------------------------------------------------------------------------------------------------------

        if (Input.GetKey(interact))
        {
            if (canInteract == true)
            {
                //pickup new clothing
                if (interactObject.tag == "Clothing")
                {
                    Clothes.Add(interactObject.name);
                    Clothes.Add(Clothes[0]);
                    Clothes.Remove(Clothes[1]);
                    Clothes.Remove(Clothes[0]);
                    
                    //deactivate object and remove
                    interactObject.SetActive(false);
                    interactObject = null;
                }
                //if it's not a clothing item
                else
                {

                }
            }
        }
    }


    //--------------------------------------------------------------------------------------------------------------------------

    //Clothes list sets the clothes abilities
    private void clothesFinder()
    {

    }

    //--------------------------------------------------------------------------------------------------------------------------

    void FixedUpdate()
    {
        //calling move function to run and jump
        cc.Move(horizontalMove * Time.fixedDeltaTime, false, jumping);
    }
}
