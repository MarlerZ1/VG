using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void MainMenu(){
         GameStateController.Instance.ChangeGameState(GameStateController.GameState.Normal);
        SceneManager.LoadScene("Menu");
    }
    public void PlayGame(){
        GameStateController.Instance.ChangeGameState(GameStateController.GameState.Normal);
    }
}
