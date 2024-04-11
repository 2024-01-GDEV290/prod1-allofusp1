using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BearState
{
    territorial,
    satisfied,
}
public class Bear : Character
{
    [SerializeField] List<Item> inventory;
    [SerializeField] string[] blockingLines;
    [SerializeField] string[] satisfiedLines;
    [SerializeField] GameEventTrigger openGateTrigger;
    [SerializeField] GameObject stumpWaypoint;
    [SerializeField] AudioClip[] calmInteractSounds;
    [SerializeField] BearState state;

    private void Start()
    {
        SetIdleAnimation();
        state = BearState.territorial;
    }


    public override void CharacterBehavior()
    {
        if (state == BearState.territorial)
        {
            SetAnimation("angry");
            InitiateDialogue(blockingLines, new List<GameEventTrigger> { idleTrigger });
        } else if (state == BearState.satisfied)
        {
            InitiateDialogue(satisfiedLines, new List<GameEventTrigger> { idleTrigger });
        }

    }
    public void AllowPassage()
    {
        SetAnimation("walking");
        InitiateDialogue(satisfiedLines);
        Invoke(nameof(SetIdleAnimation), 3);
        actor.MoveToWaypoint(stumpWaypoint.transform);
        openGateTrigger.Raise();
    }
}
