using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Character
{
    [SerializeField] List<Item> inventory;
    [SerializeField] Item desiredItem;
    [TextArea][SerializeField] string satisfiedDialogue;
    [SerializeField] GameEventTrigger openGateTrigger;
    [SerializeField] GameObject stumpWaypoint;


    public override void CharacterBehavior()
    {
            Debug.Log(defaultDialogue); 
    }

    public void LeaveCave()
    {
        Debug.Log(satisfiedDialogue);
        actor.MoveToWaypoint(stumpWaypoint.transform);
        openGateTrigger.Raise();
    }
}
