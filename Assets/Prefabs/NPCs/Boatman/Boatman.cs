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
    [Header("Set In Inspector")]
    [SerializeField] string[] interactionCompleteLines;
    [SerializeField] string[] missingOarLines;
    [SerializeField] string[] receivedOarLines;
    [SerializeField] string[] waitingLines;
    [SerializeField] string[] departingLines;
    [SerializeField] int[] highTides;
    [SerializeField] Item desiredItem;
    [SerializeField] GameEventTrigger crossLakeTrigger;
    [SerializeField] GameObject missingOar;


    [Header("Set Dynamically")]
    [SerializeField] BoatmanState state;
    private bool interactionComplete = false;
    private Tide tide;


    private void Start()
    {
        tide = GameObject.Find("Lake").GetComponent<Tide>();
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
            if (player.currentlyHeldItem && player.currentlyHeldItem.GetComponent<ItemAvatar>().item == desiredItem)
            {
                Destroy(player.currentlyHeldItem);
                missingOar.SetActive(true);
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
            Debug.Log("ReadyCheck");
            int currentTime = CheckTime();
            Debug.Log(currentTime);
            if (highTides.Contains(currentTime))
            {
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
