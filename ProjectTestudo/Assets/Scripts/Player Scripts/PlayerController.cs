using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody rb;

    [SerializeField]public MovementController mover;
    [SerializeField]StateMachine stateMachine;

    public Vector3 direction = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        //stateMachine.Update();
    }
}
