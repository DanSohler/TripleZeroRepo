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
    //clothing use key
    [SerializeField]
    KeyCode clothingAbility = KeyCode.Q;
    //swap active clothes key
    [SerializeField]
    KeyCode swapClothes = KeyCode.S;
    //Pause button
    [SerializeField]
    KeyCode pauseButton = KeyCode.Space;
    //--------------------------------------------------------------------------------------------------------------------------
    //movement veriables
    [SerializeField]
    private float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jumping = false;

    //--------------------------------------------------------------------------------------------------------------------------
    //Swap Clothes restrictions
    private float swapDelay;
    private bool canSwap;

    //--------------------------------------------------------------------------------------------------------------------------
    //pause menu system
    [SerializeField]
    private GameManager gm;
    private float menuOpenLimit = 0;


    //--------------------------------------------------------------------------------------------------------------------------
    //Clothes Systems
    [SerializeField]
    private float climbSpeed = 2f;
    [SerializeField]
    private Rigidbody2D rb;
    public bool canClimb, isRope;

    [SerializeField]
    private Transform prefab;
    private float canPlace;

    //--------------------------------------------------------------------------------------------------------------------------
    //Levers and Buttons Requirements
    public InteractableObject IOs;

    //--------------------------------------------------------------------------------------------------------------------------
    //interact systems

    public bool canInteract = true;
    public GameObject interactObject = null;
    private List<string> Clothes;

    public Sprite sneakerSprite;
    public Sprite runnerSprite;
    


    private void Start()
    {
        Clothes = new List<string>();
        Clothes.Add("Null");
        Clothes.Add("Null");
    }

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    //--------------------------------------------------------------------------------------------------------------------------
    void Update()
    {

        //Reducing swap clothes timer
        if (swapDelay > 0)
        {
            swapDelay -= Time.deltaTime;
        }
        else
        {
            canSwap = true;
        }

        if (canPlace > 0)
        {
            canPlace -= Time.deltaTime;
        }
        if (menuOpenLimit > 0)
        {
            menuOpenLimit -= Time.deltaTime;
        }
        //--------------------------------------------------------------------------------------------------------------------------
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
            //Debug.Log("Why Chara");
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
                    IOs.Activate();
                    //Debug.Log(IOs);
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------
        //use ability
        if (Input.GetKey(clothingAbility))
            {
            if (Clothes[0] == "Sweat_Bands")
            {
                if (canClimb == true)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    if (Input.GetKey(jump))
                    {
                        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (climbSpeed * Time.deltaTime), transform.position.z);
                    }
                }
                else if (canClimb == false)
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
            else if (Clothes[0] == "Sneakers")
            {
                if (canPlace <= 0)
                {
                    canPlace = 5;
                    Debug.Log("hi");
                    Instantiate(prefab, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
                }
            }
            else if (isRope == true)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                if (Input.GetKey(jump))
                {
                    this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + (climbSpeed * Time.deltaTime), transform.position.z);
                }
            }
        }
        else if (rb.constraints == RigidbodyConstraints2D.FreezePositionY)
        {
            rb.constraints = RigidbodyConstraints2D.None;

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //--------------------------------------------------------------------------------------------------------------------------
        //swap active clothes
        if (Input.GetKey(swapClothes))
        {
            if (canSwap == true)
            {
                Clothes.Add(Clothes[1]);
                Clothes.Add(Clothes[0]);
                Clothes.Remove(Clothes[1]);
                Clothes.Remove(Clothes[0]);

                canSwap = false;
                swapDelay = 1f;

                /* for (int i = 0; i < Clothes.Count; i++)
                {
                    Debug.Log(message: i + " " + Clothes[i]);
                } */
            }
        }

        if (Input.GetKey(pauseButton))
        {
            if (menuOpenLimit <= 0)
            {
                gm.PauseMenu();
                menuOpenLimit = 0.5f;
            }
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------

    void FixedUpdate()
    {
        //calling move function to run and jump
        cc.Move(horizontalMove * Time.fixedDeltaTime, false, jumping);
    }
}
