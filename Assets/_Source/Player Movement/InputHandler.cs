using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : IInputHandler
{
    PlayerControls playerControls;

    public event Action<bool> OnInputHold;
    public event Action OnInputClick;

    public InputHandler()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();
    }

    public void GetInputHold(bool active)
    {
        if (active)
        {
            ListenJumpHold();
        }
        else StopListenJumpHold();
    }
    public void GetInputClick(bool active)
    {
        if (active)
        {
            ListenJumpClick();
        }
        else StopListenJumpClick();
    }

    private void ListenJumpHold()
    {
        playerControls.Main.Jump.started += OnInputHoldStarted;
        playerControls.Main.Jump.canceled += OnInputHoldCanceled;
    }

    private void ListenJumpClick()
    {
        playerControls.Main.Jump.performed += OnInputClickPerformed;
    }

    private void StopListenJumpHold()
    {
        playerControls.Main.Jump.started -= OnInputHoldStarted;
        playerControls.Main.Jump.canceled -= OnInputHoldCanceled;
    }

    private void StopListenJumpClick()
    {
        playerControls.Main.Jump.performed -= OnInputClickPerformed;
    }

    private void OnInputHoldStarted(InputAction.CallbackContext context)
    {
        OnInputHold?.Invoke(true);
    }
    private void OnInputHoldCanceled(InputAction.CallbackContext context)
    {
        OnInputHold?.Invoke(false);
    }

    private void OnInputClickPerformed(InputAction.CallbackContext context)
    {
        OnInputClick?.Invoke();
    }

}
