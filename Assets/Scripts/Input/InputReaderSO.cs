using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game Manager/Input Reader")]
public class InputReaderSO : ScriptableObject, PlayerControl.IGamePlayActions, PlayerControl.IDialogueActions
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
        _playerControl.GamePlay.SetCallbacks(this);
        _playerControl.Dialogue.SetCallbacks(this);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
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

    public void OnInterract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            InteractEvent.Invoke();
    }

    //Dialogue Action
    public void OnNextDialogue(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            NextDialogueEvent.Invoke();
    }

    public void EnableGameplay()
    {
        _playerControl.GamePlay.Enable();
    }

    public void EnableDialogue()
    {
        _playerControl.Dialogue.Enable();
    }

    public void DisableAllInput()
    {
        _playerControl.GamePlay.Disable();
    }

}
