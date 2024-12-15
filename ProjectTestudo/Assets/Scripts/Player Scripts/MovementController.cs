using UnityEngine;

[System.Serializable]
public class MovementController : MonoBehaviour
{

    [HideInInspector] Animator animator;
    [HideInInspector] Rigidbody rb;

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



    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
}
