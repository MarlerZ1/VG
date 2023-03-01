using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    private static GameObject _player ;

    public static GameObject Player => _player;

    private void Awake()
    {
        _player = gameObject;
    }
}
