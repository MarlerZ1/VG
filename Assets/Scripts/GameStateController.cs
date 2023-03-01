using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// [DefaultExecutionOrder(-100)]
public class GameStateController : MonoBehaviour
{
    private static GameStateController _instance;
    static public GameStateController Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameStateController>();
                Debug.Log(_instance);
            }
            return _instance;
        }
        private set {
            _instance = value;
        }
    }
    public enum GameState {
        Normal, 
        Pause,
        Dialogue,
    }

    private GameState _currentState;

    public GameState CurrentState => _currentState;

    public Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeGameState(GameState newState) {
        _currentState = newState;
        
        switch(newState) {
            case GameState.Normal:
                InputSystemSingleton.InputSystem.Move.Enable();      //          InputSystemSingleton.InputSystem.Move.Enable();
                InputSystemSingleton.InputSystem.Attack.Enable();

                break;
            case GameState.Dialogue:
                InputSystemSingleton.InputSystem.Move.Disable();
                InputSystemSingleton.InputSystem.Attack.Disable();

                break;
            case GameState.Pause:
            
            break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    [ContextMenu("Test Game State")]
    // NaughtyAttributes
    public void TestState() {
        if (_currentState == GameState.Normal) {
            ChangeGameState(GameState.Dialogue);
        }
        else {
            ChangeGameState(GameState.Normal);
        }
    }

}
