using UnityEngine;

public class InputSystemSingleton : MonoBehaviour
{
    private static InputSystem _iSys;

    public static InputSystem ISys
    {
        get
        {
            if (_iSys == null)
            {
                _iSys = new InputSystem();
            }
            return _iSys;
        }
        private set { }
    }


}
