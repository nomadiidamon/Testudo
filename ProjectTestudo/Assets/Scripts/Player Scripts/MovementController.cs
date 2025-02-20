using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementController : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    public Vector3 moveVector = Vector3.zero;
    [SerializeField] GravityController gravController;

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

    [Header("Rotation Speed")]
    [SerializeField] public float rotateToCameraSpeed = 1.0f;

    public PlayerMoveAction moveAction;
    // Jump action
    // dodge action
    // graity shift action
    // grapple action


    [SerializeField] private CinemachineFreeLook freeLookCamera;
    [SerializeField] private CinemachineBrain cameraBrain;

    void Awake()
    {
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
            moveVector = moveAction.inputVector3;
            rb.rotation = Quaternion.Lerp(rb.rotation, freeLookCamera.transform.rotation, Time.deltaTime * rotateToCameraSpeed);
            if (rb.transform.forward != transform.forward)
            {
                transform.forward = freeLookCamera.transform.forward;
                rb.transform.forward = transform.forward;

            }
        }
        else
        {
            moveVector = Vector3.zero; // Stop movement if no input
        }
        Vector3 newMove = moveVector;
        newMove  = gravController.UpdateGravity(newMove);
        rb.AddForce(newMove);
        
    }


    private void Update()
    {
        UpdateMovementDirection();
        if (rb != null)
        {
            rb.MovePosition(rb.position + ((moveVector) * walkSpeed * Time.deltaTime));
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
