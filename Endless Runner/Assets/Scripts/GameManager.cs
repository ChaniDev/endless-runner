using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerMovement insPlayerMovement; 

    public static int playerHealth = 2;



    private void Start() 
    {
        insPlayerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void PlayerStatus(string playerStatus)
    {
        Debug.Log("Tumble");
    }
}
