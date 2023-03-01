using UnityEngine;

public class InputSystemSingleton : MonoBehaviour
{
    private static InputSystem _inputSystem;

    public static InputSystem InputSystem
    {
        get
        {
            if (_inputSystem == null)
            {
                _inputSystem = new InputSystem();
            }
            return _inputSystem;
        }
        private set { }
    }

    private void OnEnable() {
        InputSystem.Enable();
    }

    private void OnDisable() {
        InputSystem.Disable();
    }

}
