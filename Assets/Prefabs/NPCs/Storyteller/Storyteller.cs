using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum StorytellerState
{
    idle,
    talking,
    flute
}
public class Storyteller : Character
{
    [SerializeField] string[] interactionCompleteLines;
    [SerializeField] string[] nightTimeLines;
    [SerializeField] string[] dayTimeLines;

    [SerializeField] int nightStartTime = 18;
    [SerializeField] int nightEndTime = 5;
    private bool interactionComplete = false;
    [SerializeField] GameEventTrigger playFluteTrigger;
    [SerializeField] GameEventTrigger openGateTrigger;
    [SerializeField] GameEventTrigger successSoundTrigger;

    [SerializeField] StorytellerState state;


    private void Start()
    {
        state = StorytellerState.idle;
    }

    public override void CharacterBehavior()
    {
        if (interactionComplete) {
            InitiateDialogue(interactionCompleteLines);
        }
        else if (CheckTime() >= nightStartTime || CheckTime() <= nightEndTime)
        {
            TriggerSuccessSound();
            InitiateDialogue(nightTimeLines, new List<GameEventTrigger> { playFluteTrigger });
            interactionComplete = true;
        }
        else
        {
            InitiateDialogue(dayTimeLines);
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

    public void PlaySong()
    {
        Debug.Log("Storyteller: Doot doot doot. I'm playing my song.");
        openGateTrigger.Raise();
    }

    void openGate()
    {

    }

}
