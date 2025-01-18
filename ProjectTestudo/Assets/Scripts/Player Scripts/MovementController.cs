using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementController : MonoBehaviour
{

    [HideInInspector] Animator animator;
    [HideInInspector] Rigidbody rb;
    public Vector3 moveVector = Vector3.zero;

    [Header("Movement Factors")]
    [SerializeField] public float walkSpeed;
    [SerializeField] public float sprintSpeed;
    [SerializeField] public float crouchSpeed;

    [Header("Jump Factors")]
    [SerializeField] public int jumpMax;
    [SerializeField] public float jumpForce;

    [Header("Dodge Factors")]
    [SerializeField] public float dodgeForce;
    [SerializeField] public float dodgeTime;

    [Header("Grapple Factors")]
    [SerializeField] public float grappleForce;
    [SerializeField] public float grappleSpeed;
    [SerializeField] public float grappleDistance;


    public PlayerMoveAction moveAction;
    // Jump action
    // dodge action
    // graity shift action
    // grapple action


    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (moveAction == null)
        {
            moveAction = GetComponent<PlayerMoveAction>();
            moveAction.enabled = true;
            if (moveAction != null)
            {
                moveAction.onInputPerformed.AddListener(UpdateMovementDirection);
            }
        }
        
        // initialize all other input actions
    }

    private void UpdateMovementDirection()
    {
        if (moveAction.inputVector3.sqrMagnitude > 0.01f) // If input is significant
        {
            moveVector = moveAction.inputVector3.normalized;
        }
        else
        {
            moveVector = Vector3.zero; // Stop movement if no input
        }
    }

    void FixedUpdate()
    {
        UpdateMovementDirection();
        if (rb != null)
        {
            rb.MovePosition(rb.position + moveVector * walkSpeed * Time.fixedDeltaTime);
        }   
    }

    void OnDestroy()
    {
        if (moveAction != null)
        {
            moveAction.onInputPerformed.RemoveListener(UpdateMovementDirection);
        }
    }
}
