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
    [SerializeField] AudioClip[] calmInteractSounds;


    public override void CharacterBehavior()
    {
        audioSource.PlayOneShot(defaultInteractSounds[Random.Range(0,defaultInteractSounds.Length - 1)]);    
        Debug.Log(defaultDialogue); 
    }

    public void LeaveCave()
    {
        Debug.Log(satisfiedDialogue);
        actor.MoveToWaypoint(stumpWaypoint.transform);
        defaultInteractSounds = calmInteractSounds;
        openGateTrigger.Raise();
    }
}
