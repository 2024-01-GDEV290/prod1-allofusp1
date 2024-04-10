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


    private void Start()
    {
        SetAnimation("idle");
    }

    public override void CharacterBehavior()
    {
        SetAnimation("talking");
        if (interactionComplete) {
            InitiateDialogue(interactionCompleteLines, new List<GameEventTrigger>() { idleTrigger });
        }
        else if (IsNight())
        {
            TriggerSuccessSound();
            InitiateDialogue(nightTimeLines, new List<GameEventTrigger> { playFluteTrigger });
            interactionComplete = true;
        }
        else
        {
            InitiateDialogue(dayTimeLines, new List<GameEventTrigger>() { idleTrigger });
        }
    }

    bool IsNight()
    {
        return CheckTime() >= nightStartTime || CheckTime() <= nightEndTime;
    }

    public void PlaySong()
    {
        SetAnimation("flute");
        Debug.Log("Storyteller: Doot doot doot. I'm playing my song.");
        openGateTrigger.Raise();
/*Swap voice here for flute song audioclip when implemented*/
        Invoke(nameof(SetIdleAnimation), voice.length + 2);
    }

    void LoopSong()
    {

    }
    public void ObjectiveCompleteBehavior()
    {
        if (interactionComplete)
        {
            if (IsNight())
            {
                SetAnimation("flute");
/*                audioSource.loop = true;
                audioSource.Play();*/
            }
            else 
            {
/*                audioSource.Stop();*/
                SetIdleAnimation();
            }
        }
    }
}
