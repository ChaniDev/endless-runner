using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int currentLane = 0; 
    [SerializeField] int selectedLane = 0;

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

            UpdatePlayerLocation();
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

            UpdatePlayerLocation();
        }
    }

    void FixedUpdate()
    {
        
    }

    void UpdatePlayerLocation()
    {
        if(selectedLane == currentLane)
        {
            return;
        }

        switch(selectedLane)
        {
            case -1:
                transform.position = new Vector3(4,transform.position.y,transform.position.z);
                currentLane = selectedLane;
                break;

            case 0:
                transform.position = new Vector3(0,transform.position.y,transform.position.z);
                currentLane = selectedLane;
                break;

            case +1:
                transform.position = new Vector3(-4,transform.position.y,transform.position.z);
                currentLane = selectedLane;
                break;
        }
    }
}
