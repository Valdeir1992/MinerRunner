using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    private GameInputs _gameInputs;

    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    #endregion
    private void Awake()
    {
        _gameInputs = new GameInputs();
    }

    private void OnEnabele ()
    {
        _gameInputs.Enable();
    }

    private void OnDisable ()
    { 
        _gameInputs.Disable(); 
    }

    private void Start ()
    {
        _gameInputs.Gameplay.PrimaryTouch.started += ctx => StartPrimaryTouch(ctx);
        _gameInputs.Gameplay.PrimaryTouch.canceled += ctx => EndPrimaryTouch(ctx);
    }

    private void StartPrimaryTouch (InputAction.CallbackContext context)
    {

    }

    private void EndPrimaryTouch (InputAction.CallbackContext context)
    {

    }
}
