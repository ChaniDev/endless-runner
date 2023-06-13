using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool isGrounded = false;
    PlayerMovement insPlayerMovement;

    private void Start() 
    {
        insPlayerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    private void Update() 
    {
            insPlayerMovement.PlayerGrounded(isGrounded);
    }

    private void OnTriggersEnter(Collider other) 
    {
        if(other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Ground"))
        {
            isGrounded = false;
        }    
    }
}
