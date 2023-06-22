using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //------Refrence------
    GameManager insGameManager;
    [SerializeField] Camera playerCamera;
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] BoxCollider playerBoxCollider;

        [Space]
    //------Variables------
    [SerializeField] int currentLane = 0; 
    [SerializeField] int selectedLane = 0;
    [SerializeField] int lastActiveLane = 0;

        [Space]
        
    [SerializeField] bool playerIsRolling = false;
    [SerializeField] bool playerGrounded = false;

        [Space]

    [SerializeField] bool rollEnabled = false;
    [SerializeField] bool jumpEnabled = false;
    bool jumpRequest = false;
    int jumpBufferClock = 0;
    [SerializeField] int jumpBufferTime = 10;

        [Space]

    [SerializeField] float movementSpeed = 0.3f;
    [SerializeField] float playerGravity = 10;
    [SerializeField] float jumpForce = 1;

        [Space]

    [SerializeField] float internalRollCount = 0;
    [SerializeField] float rollTimer = 10;

 
        [Space]

    [SerializeField] bool inputEnable = true;

    //------------ Private Variables --------------
    private Vector3 targetPosition ;


    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {

        if(playerGrounded)
        {
            jumpEnabled = true;
        }
        else
        {
            jumpEnabled = false;
        }

        if(playerIsRolling)
        {
            rollEnabled = false;
        }
        else
        {
            rollEnabled = true;
        }


    //--------- Player Control ----------
        if(inputEnable)
        {
            if(Input.GetButtonDown("Up"))
            {
                jumpRequest = true;
            }

            if(Input.GetButtonDown("Down"))
            {
                if(rollEnabled)
                {
                    PlayerRoll();
                }
            }

            if(Input.GetButtonDown("Left"))
            {
                Debug.Log("Left");

                lastActiveLane = currentLane;

                switch(currentLane)
                {
                    case 0:
                        selectedLane = -1;
                        break;

                    case -1:
                        selectedLane = -1;

                        insGameManager.PlayerStatus("Tumble");

                        break;

                    case +1:
                        selectedLane = 0;
                        break;
                }

                AdjustBoxCollider("Big");
            }

            if(Input.GetButtonDown("Right"))
            {
                Debug.Log("Right");

                lastActiveLane = currentLane;

                switch(currentLane)
                {
                    case 0:
                        selectedLane = +1;
                        break;

                    case -1:
                        selectedLane = 0;
                        break;

                    case +1:
                        selectedLane = +1;

                        insGameManager.PlayerStatus("Tumble");

                        break;
                }

                AdjustBoxCollider("Big");
            }
        }
    }

    void FixedUpdate()
    {
    //---- Player Movement ----
        transform.position = Vector3.Lerp
            (transform.position,
            new Vector3
                (selectedLane*-4,
                this.transform.position.y,
                this.transform.position.z),
            movementSpeed);
        currentLane = selectedLane;

    // ---- Camera Movement ----
        playerCamera.transform.position = Vector3.Lerp
            (playerCamera.transform.position,
            new Vector3
                (selectedLane*-1f,
                playerCamera.transform.position.y,
                playerCamera.transform.position.z),
            0.2f);

    // ----- Player Gravity -----
        playerRigidbody.AddForce(0,playerGravity*-10,0);

    // ----- Player Roll ------
        if(playerIsRolling)
        {
            internalRollCount++;

            if(internalRollCount > rollTimer)
            {
                AdjustBoxCollider("Big");
                playerIsRolling = false;
                internalRollCount = 0;
            }
        }

        if(jumpRequest)
        {
            jumpBufferClock++;

            if(jumpBufferClock < jumpBufferTime)
            {
                if(jumpEnabled)
                {
                    jumpRequest = false;
                    jumpBufferClock = 0;
                    PlayerJump();
                }
            }  
            else
            {
                jumpBufferClock = 0;
                jumpRequest = false;
            }          
        }
    }

    void PlayerJump()
    {
        AdjustBoxCollider("Big");

    //---- Zero gravity force to have constant jump!-----
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x,0);

        playerRigidbody.AddForce(0,jumpForce*100,0);

        playerIsRolling = false;
    }

    void PlayerRoll()
    {
        AdjustBoxCollider("Small");

        internalRollCount = 0;

        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x,0);

        playerRigidbody.AddForce(0,-jumpForce*150,0);

        playerIsRolling = true;

    }

    public void PlayerGrounded(bool isGrounded)
    {
        playerGrounded = isGrounded;
    }

    void AdjustBoxCollider(string inputCommand)
    {
        switch (inputCommand)
        {
            case "Small":

                playerBoxCollider.center = new Vector3(0,-0.25f,0);
                playerBoxCollider.size = new Vector3(1,0.5f,1);

                break;

            case "Big":
            
                playerBoxCollider.center = new Vector3(0,0,0);
                playerBoxCollider.size = new Vector3(1,1,1);

                break; 

            default:

                Debug.LogError("Invalid inputCommand!");

                break;
        }
    }
}
