using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] float radiusToCheck;
    [SerializeField] float distanceToCheck;

    public bool isGrounded;
   

    void Update()
    {
        if (Physics.SphereCast(transform.position, radiusToCheck, Vector3.down, out RaycastHit hitInfo, distanceToCheck))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
