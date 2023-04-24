using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerHealth = 2;

    void Update()
    {
        if(playerHealth.Equals(1000)) //----- Temp--- Fix Me---
        {
            Debug.Log("Death");
        }
    }
}
