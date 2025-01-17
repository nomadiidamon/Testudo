using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody rb;

    [SerializeField]public PlayerInputManager inputManager;

    [SerializeField]public AbilityController abilityController;
    [SerializeField]public MovementController mover;

    public Vector3 direction = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        //stateMachine.Update();
    }
}
