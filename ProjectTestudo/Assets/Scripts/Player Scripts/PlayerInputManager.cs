using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    PlayerControls playerControls;

    Vector2 moveInput;
    

    void Awake()
    {
        playerControls = GetComponent<PlayerControls>();
   
        playerControls.Enable();
        playerControls.Player.Move.performed += ctx => ctx.ReadValue<Vector2>();
        playerControls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
