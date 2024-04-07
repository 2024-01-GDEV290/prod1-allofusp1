using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : Character
{
    [SerializeField] string[] defaultLines;
    
    public override void CharacterBehavior()
    {
        InitiateDialogue(defaultLines);
    }

}
