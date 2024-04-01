using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum DialogueState
{
    ready,
    typing
}
public class Dialogue : MonoBehaviour
{
    public static Dialogue S;
    public TextMeshProUGUI text;
    public static string[] lines;
    public float textSpeed;
    private int lineIndex;
    private DialogueState state;
    [SerializeField] GameEventTrigger nextLineTrigger;

    private void Awake()
    {
        text.text = string.Empty;
        S = this;
    }
    private void OnEnable()
    {
        lineIndex = 0;
        text.text = string.Empty;
    }
    public void StartDialogue()
    {
        
        gameObject.SetActive(true);
        lineIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        state = DialogueState.typing;
        text.text = string.Empty;
        foreach (char c in lines[lineIndex].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        state = DialogueState.ready;
        lineIndex += 1;
    }

    public void NextLine()
    {
        if (state == DialogueState.ready)
        {
            InputManager.S.SetDialogue();
            if (lineIndex < lines.Length)
            {


                StartCoroutine(TypeLine());
            }
            else
            {

                EndInteraction();
            }
        }
    }
    void EndInteraction()
    {
        lineIndex = 0;
        text.text = string.Empty;
        InputManager.S.SetOnFoot();
    }
}
