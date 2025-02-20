using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField] public AbilityController abilityController;
    [SerializeField] public MovementController mover;

    public Vector3 direction = Vector3.zero;

    void Awake()
    {
        mover = GetComponentInChildren<MovementController>();
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (mover != null)
        {
            //direction = mover.moveVector + direction;
        }
    }
}
