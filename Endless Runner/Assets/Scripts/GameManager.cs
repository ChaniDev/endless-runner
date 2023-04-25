using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerHealth = 2;

    public void PlayerStatus(string playerStatus)
    {
        switch(playerStatus)
        {
            case "Tumble":
                Debug.Log("Tumble");
            break;

            case "Dead":

            break;
        }
    }
}
