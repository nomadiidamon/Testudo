using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMoveAction : PlayerInputActionBase
{
    private Vector2 input;
    public Vector3 inputVector3 = Vector3.zero;
    protected override void HandleInput(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>(); // Read input as a Vector2
        inputVector3 = new Vector3(input.x, 0, input.y);
    }
}
