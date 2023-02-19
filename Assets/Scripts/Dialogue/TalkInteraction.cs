using Ink.Runtime;
using System;
using TMPro;
using UnityEngine;

public class TalkInteraction : InteractionHandler
{
    public Action OnDialogueStart;
    public Action OnDialogueStop;

    [SerializeField] private TextAsset _inkJsonAsset;
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private GameObject _dialogue;

    private Story _story;
    override public void Interaction()
    {
        //_story = new Story(_inkJsonAsset.text);
        print("I TALK! I TAAALK!");
        //DisplayNextLine();
       // OnDialogueStart?.Invoke();
    }

    private void DisplayNextLine()
    {
        if (!_story.canContinue)
        {
            OnDialogueStop?.Invoke();
            return;
        }

        string text = _story.Continue(); // gets next line
        text = text?.Trim(); // removes white space from text
        _textField.text = text; // displays new text
    }
}
