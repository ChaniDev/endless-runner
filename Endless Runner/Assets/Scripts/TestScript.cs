using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 0.5f);
    }
}
