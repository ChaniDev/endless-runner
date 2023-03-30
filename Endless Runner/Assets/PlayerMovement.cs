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
        }

        if(Input.GetButtonDown("Jump"))
        {

        }

        Debug.Log(currentLane);
    }

    void FixedUpdate()
    {
        if(currentLane == -1)
        {
            Vector3 targetPosition = new Vector3(4,transform.position.y,0);

            transform.position = 
            Vector3.MoveTowards(transform.position,targetPosition,0.5f);
        }
        else if(currentLane == 0)
        {
            Vector3 targetPosition = new Vector3(0,transform.position.y,0);

            transform.position = 
            Vector3.MoveTowards(transform.position,targetPosition,0.5f);
        }
        else if(currentLane == 1)
        {
            Vector3 targetPosition = new Vector3(-4,transform.position.y,0);

            transform.position = 
            Vector3.MoveTowards(transform.position,targetPosition,0.5f);
        }
    }
}
