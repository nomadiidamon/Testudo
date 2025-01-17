using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class PlayerInputActionBase : MonoBehaviour
{
    [Tooltip("The Input Action to be tracked.")]
    public InputAction action;

    [Tooltip("The name of the action.")]
    [SerializeField]public string actionName;

    [Tooltip("Unity Event triggered when the input action is performed.")]
    public UnityEvent onInputPerformed; // Trigger when input conditions are met


    protected virtual void OnEnable()
    {

        if (action != null)
        {
            action.Enable();
            action.performed += OnInputPerformed;
        }
        else
        {
            Debug.LogWarning($"{gameObject.name}: No InputAction assigned to {nameof(PlayerInputActionBase)}.");
        }
    }
    protected virtual void OnDisable()
    {
        if (action != null)
        {
            action.performed -= OnInputPerformed;
            action.Disable();
        }
    }

    private void OnInputPerformed(InputAction.CallbackContext context)
    {
        onInputPerformed?.Invoke(); // Trigger the UnityEvent
        if (onInputPerformed == null)
        {
            Debug.LogWarning($"{gameObject.name}: No UnityEvent assigned for {nameof(onInputPerformed)}.");
        }
        HandleInput(context);       // Call the overridable method for custom logic
    }

    /// <summary>
    /// Override this method in derived classes to handle input logic.
    /// </summary>
    protected abstract void HandleInput(InputAction.CallbackContext context);



}
