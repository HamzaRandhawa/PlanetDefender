using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Input/Input Manager")]
public class InputManager : ScriptableObject, PlayerInputActions.IPlayerActions
{
    public event UnityAction<Vector2> moveEvent;
    public event UnityAction moveCanceledEvent;

    private PlayerInputActions controls;

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new PlayerInputActions();
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
            moveEvent?.Invoke(context.ReadValue<Vector2>());
        if (context.canceled)
            moveCanceledEvent?.Invoke();
    }
}
