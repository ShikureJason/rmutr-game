using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game Manager/Input Reader")]
public class InputReaderSO : ScriptableObject, PlayerControl.IOnGameActions
{
    public UnityAction<Vector2> MoveEvent;
    public UnityAction JumpEvent;
    public UnityAction<bool> SprintEvent;
    public UnityAction<Vector2> MoveCameraEvent;
    public UnityAction<Vector2> ZoomCameraEvent;
    public UnityAction InteractEvent;
    public UnityAction<bool> ControlCamEvent;
    public UnityAction EscapeGameEvent;

    public UnityAction NextDialogueEvent;

    public UnityAction EscapeMenuEvent;

    private PlayerControl _playerControl;

    private void OnEnable()
    {
        _playerControl = new PlayerControl();
        _playerControl.OnGame.SetCallbacks(this);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        JumpEvent.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMoveCamera(InputAction.CallbackContext context)
    {
        MoveCameraEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            SprintEvent.Invoke(true);
        if (context.phase == InputActionPhase.Canceled)
            SprintEvent.Invoke(false);
    }

    public void OnZoomCamera(InputAction.CallbackContext context)
    {
        ZoomCameraEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void EnableGameplay()
    {
        _playerControl.OnGame.Enable();
    }

    public void DisableAllInput()
    {
        _playerControl.OnGame.Disable();
    }

}
