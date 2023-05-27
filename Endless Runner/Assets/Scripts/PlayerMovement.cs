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

    [SerializeField] float movementSpeed = 0.3f;
    [SerializeField] float playerGravity = 10;
    [SerializeField] float jumpForce = 1;

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
        if(inputEnable)
        {
            if(Input.GetButtonDown("Up"))
            {
                PlayerJump();
            }

            if(Input.GetButtonDown("Down"))
            {
                PlayerRoll();
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
                (selectedLane*-0.5f,
                playerCamera.transform.position.y,
                playerCamera.transform.position.z),
            0.2f);

    // ----- Player Gravity -----
        playerRigidbody.AddForce(0,playerGravity*-10,0);
    }

    void PlayerJump()
    {
        AdjustBoxCollider("Big");

    //---- Zero gravity force to have constant jump!-----
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x,0);

        playerRigidbody.AddForce(0,jumpForce*100,0);
    }

    void PlayerRoll()
    {
        AdjustBoxCollider("Small");
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
