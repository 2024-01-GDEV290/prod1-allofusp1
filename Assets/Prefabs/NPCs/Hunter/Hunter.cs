using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : Character
{
    [SerializeField] string[] defaultLines;

    private void Start()
    {
        SetIdleAnimation();
    }
    public override void CharacterBehavior()
    {
        animator.SetTrigger("talking");
        InitiateDialogue(defaultLines, new List<GameEventTrigger>() { idleTrigger });
    }

}
