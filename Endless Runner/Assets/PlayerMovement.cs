using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int currentLane = 0; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Left"))
        {
            if(currentLane == 1)
            {
                currentLane = 0;
            }
            else if(currentLane == 0)
            {
                currentLane = -1;
            }

            UpdateLocation();
        }

        if(Input.GetButtonDown("Right"))
        {
            if(currentLane == -1)
            {
                currentLane = 0;
            }
            else if(currentLane == 0)
            {
                currentLane = 1;
            }

            UpdateLocation();
        }

        Debug.Log(currentLane);
    }

    void UpdateLocation()
    {
        if(currentLane == -1)
        {
            transform.position = new 
                Vector3(4,transform.position.y,transform.position.z);
        }
        if(currentLane == 0)
        {
            transform.position = new 
                Vector3(0,transform.position.y,transform.position.z);
        }
        if(currentLane == 1)
        {
            transform.position = new 
                Vector3(-4,transform.position.y,transform.position.z);
        }
    }
}
