using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyteller : Character
{
    [TextArea][SerializeField] string nightTimeDialogue;
    [SerializeField] string[] nightTimeLines;
    [SerializeField] string[] dayTimeLines;
    [TextArea][SerializeField] string dayTimeDialogue; 
    [SerializeField] GameEventTrigger openGateTrigger;
    [SerializeField] int nightStartTime = 18;
    [SerializeField] int nightEndTime = 5;
    [SerializeField] GameEventTrigger successSoundTrigger;
/*    [Header("Sprite Display States")]
    [SerializeField] BearState state;
    [SerializeField] Sprite calmSprite;
    [SerializeField] Sprite angrySprite;
    [SerializeField] Sprite sleepingSprite;
    [SerializeField] Sprite walkingSprite;*/

    public override void CharacterBehavior()
    {
        if (CheckTime() >= nightStartTime || CheckTime() <= nightEndTime)
        {
           InitiateDialogue(nightTimeLines);
        }
        else
        {
            InitiateDialogue( dayTimeLines);
        }
    }

    int CheckTime()
    {
        return WindingTime.S.hours;
    }

    void TriggerSuccessSound()
    {
        successSoundTrigger.Raise();
    }

    void PlaySong()
    {

    }

    void openGate()
    {

    }

}
