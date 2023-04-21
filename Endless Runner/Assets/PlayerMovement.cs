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
            Debug.Log("TEs");

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
            Debug.Log("TEs");

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

    void UpdatePlayerLocation()
    {
        if(selectedLane == currentLane)
        {
            return;
        }

        switch(selectedLane)
        {
            case -1:
                transform.Translate(new Vector3(4,0,0) * Time.deltaTime * 100f);
                currentLane = selectedLane;
                break;
        }
    }
}
