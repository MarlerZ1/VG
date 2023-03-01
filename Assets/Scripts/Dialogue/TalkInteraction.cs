using Ink.Runtime;
using System;
using TMPro;
using UnityEngine;

public class TalkInteraction : InteractionHandler
{
    // public Action OnDialogueStart;
    // public Action OnDialogueStop;

    [SerializeField] private TextAsset _inkJsonAsset;
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private GameObject _dialogue;

    private Story _story;


    override public void Interaction()
    {
        if (!_story)
            _story = new Story(_inkJsonAsset.text);
        
        GameStateController.Instance.ChangeGameState(GameStateController.GameState.Dialogue);
        
        //print("I TALK! I TAAALK!");
        _dialogue.gameObject.SetActive(true);
        DisplayNextLine();
        // OnDialogueStart?.Invoke();
    }

    private void DisplayNextLine()
    {
        if (!_story.canContinue)
        {
          //  OnDialogueStop?.Invoke();
            _dialogue.gameObject.SetActive(false);
            GameStateController.Instance.ChangeGameState(GameStateController.GameState.Normal);
            _story = null;
            return;
        }

        string text = _story.Continue(); // gets next line
        text = text?.Trim(); // removes white space from text
        _textField.text = text; // displays new text
    }
}
