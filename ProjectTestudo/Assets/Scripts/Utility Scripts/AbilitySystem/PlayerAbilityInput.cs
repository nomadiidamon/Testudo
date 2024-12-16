using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityInput : MonoBehaviour
{
    private AbilityController abilityController;

    private void Awake()
    {
        abilityController = GetComponent<AbilityController>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            abilityController.ActivateAbility("Dash");
        }
    }

    // Add more input handlers for other abilities
}
