using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] Transform ObjectParent;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3
            (
                ObjectParent.position.x,
                ObjectParent.position.y,
                ObjectParent.position.z + 0.3f
            );

        ObjectParent.transform.position = newPosition;
    }
}
