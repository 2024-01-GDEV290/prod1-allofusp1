using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public enum BoatmanState
{
    missingOar,
    waitingToDepart,
    readyToDepart,
    interactionComplete
}
public class Boatman : Character
{
    [SerializeField] string[] interactionCompleteLines;
    [SerializeField] string[] missingOarLines;
    [SerializeField] string[] receivedOarLines;
    [SerializeField] string[] waitingLines;
    [SerializeField] string[] departingLines;
    BoatmanState state;
    private bool interactionComplete = false;
    [SerializeField] int[] highTides;
    [SerializeField] GameEventTrigger idleTrigger;
    [SerializeField] GameEventTrigger crossLakeTrigger;



    private void Start()
    {
        state = BoatmanState.missingOar;
        SetAnimation("idle");
    }

    public override void CharacterBehavior()
    {
        SetAnimation("talking");
        if (interactionComplete) {
            InitiateDialogue(interactionCompleteLines, new List<GameEventTrigger>() { idleTrigger });
        }
        else if(state == BoatmanState.missingOar)
        {
            if (player.currentlyHeldItem != null) // Replace this with a reference to the oar prefab later
            {
                /*Receive oar*/
                InitiateDialogue(receivedOarLines, new List<GameEventTrigger>() { idleTrigger } );
                state = BoatmanState.waitingToDepart;
            } else
            {

                InitiateDialogue(missingOarLines, new List<GameEventTrigger>() { idleTrigger });
            }
        } else if(state == BoatmanState.waitingToDepart)
        {
            InitiateDialogue(waitingLines, new List<GameEventTrigger>() { idleTrigger });
        } else if (state == BoatmanState.readyToDepart)
        {
            InitiateDialogue(departingLines, new List<GameEventTrigger>() { idleTrigger, crossLakeTrigger });
            state = BoatmanState.interactionComplete;
        }
    }

    public void ReadyCheck()
    {
        if (state == BoatmanState.readyToDepart || state == BoatmanState.waitingToDepart)
        {
            int currentTime = CheckTime();
            if (highTides.Contains(currentTime)){
                state = BoatmanState.readyToDepart;
            }
            else
            {
                state = BoatmanState.waitingToDepart;
            }
        }
    }

    public void CrossLake()
    {
        Debug.Log("Crossing Lake");
    }
    public void ObjectiveCompleteBehavior()
    {
                SetIdleAnimation();
    }
}
