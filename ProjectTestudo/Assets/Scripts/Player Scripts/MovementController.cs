using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementController : MonoBehaviour
{

    [HideInInspector] Animator animator;
    [HideInInspector] Rigidbody rb;
    public Vector3 direction = Vector3.zero;

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



    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (moveAction == null)
        {
            moveAction = GetComponent<PlayerMoveAction>();
            moveAction.enabled = true;
        }
        if (moveAction != null)
        {
            moveAction.onInputPerformed.AddListener(UpdateMovementDirection);
        }
    }

    private void UpdateMovementDirection()
    {
        direction = new Vector3(moveAction.input.x, 0, moveAction.input.y).normalized;
    }

    void FixedUpdate()
    {
        if (rb != null && direction != Vector3.zero)
        {
            rb.MovePosition(rb.position + direction * walkSpeed * Time.fixedDeltaTime);
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
