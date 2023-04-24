using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int currentLane = 0; 
    [SerializeField] int selectedLane = 0;
    [SerializeField] float movementSpeed = 0.3f;

    [SerializeField] Camera playerCamera;

    void Update()
    {
        if(Input.GetButtonDown("Left"))
        {
            Debug.Log("Left");

            switch(currentLane)
            {
                case 0:
                    selectedLane = -1;
                    break;

                case -1:
                    selectedLane = -1;
                    break;

                case +1:
                    selectedLane = 0;
                    break;
            }
        }

        if(Input.GetButtonDown("Right"))
        {
            Debug.Log("Right");

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
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        switch(selectedLane)
        {
            default :
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
                        (selectedLane*-7,
                        playerCamera.transform.position.y,
                        playerCamera.transform.position.z),
                    movementSpeed);
                break;
        }
    }
}
