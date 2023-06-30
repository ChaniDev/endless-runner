using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHit : MonoBehaviour
{
    GameManager insGameManager;


    private void Start() 
    {
        insGameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            insGameManager.PlayerStatus("Tumble");
        }    
    }
}
