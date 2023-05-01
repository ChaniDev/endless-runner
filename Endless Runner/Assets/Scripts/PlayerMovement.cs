using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //------Refrence------
    GameManager insGameManager;
    [SerializeField] Camera playerCamera;
    [SerializeField] Rigidbody playerRigidbody;

        [Space]
    //------Variables------
    [SerializeField] int currentLane = 0; 
    [SerializeField] int selectedLane = 0;
    [SerializeField] int lastActiveLane = 0;

        [Space]

    [SerializeField] float movementSpeed = 0.3f;
    [SerializeField] float playerGravity = 10;
    [SerializeField] float playerForce = 10;

        [Space]

    [SerializeField] bool inputEnable = true;


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
                playerRigidbody.AddForce(0,playerForce*100,0);
            }

            if(Input.GetButtonDown("Down"))
            {
                playerRigidbody.AddForce(0,-playerForce*100,0);
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
            }
        }
    }

    void FixedUpdate()
    {
    //---- Player Movement ----
        transform.position = Vector3.Lerp
            (transform.position,
            new Vector3
                (selectedLane*-8,
                transform.position.y,
                transform.position.z),
            movementSpeed);
        currentLane = selectedLane;

    // ---- Camera Movement ----
        playerCamera.transform.position = Vector3.Lerp
            (playerCamera.transform.position,
            new Vector3
                (selectedLane*-4,
                playerCamera.transform.position.y,
                playerCamera.transform.position.z),
            0.2f);

    // ----- Player Gravity -----
        playerRigidbody.AddForce(0,playerGravity*10,0);
    }
}
