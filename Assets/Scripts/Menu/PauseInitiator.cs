using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PauseInitiator : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    
    private bool isPaused = false;

    private void OnEnable()
    {
        InputSystemSingleton.InputSystem.Pause.Pause.performed += SwitchCondition;
    }

    private void SwitchCondition(InputAction.CallbackContext context)
    {
        SetPause(!isPaused);
    }

    private void SetPause(bool shouldPause) {
        _pauseMenu.SetActive(shouldPause);
        isPaused = shouldPause;
        GameStateController.Instance.ChangeGameState(shouldPause ? GameStateController.GameState.Pause : GameStateController.GameState.Normal);
    }

    private void OnDisable()
    {
        InputSystemSingleton.InputSystem.Pause.Pause.performed -= SwitchCondition;
    }

    public void MainMenu(){
        SetPause(false);
        SceneManager.LoadScene("Menu");
    }
    public void PlayGame(){
        SetPause(false);
    }
}
