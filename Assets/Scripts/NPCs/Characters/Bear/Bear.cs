using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BearState
{
    calm,
    angry,
    sleeping,
    walking,
}
public class Bear : Character
{
    [SerializeField] List<Item> inventory;
    [TextArea][SerializeField] string satisfiedDialogue;
    [SerializeField] GameEventTrigger openGateTrigger;
    [SerializeField] GameObject stumpWaypoint;
    [SerializeField] AudioClip[] calmInteractSounds;

    [Header("Sprite Display States")]
    [SerializeField] BearState state;
    [SerializeField] Sprite calmSprite;
    [SerializeField] Sprite angrySprite;
    [SerializeField] Sprite sleepingSprite;
    [SerializeField] Sprite walkingSprite;

    private void LateUpdate()
    {
        if (state == BearState.walking && transform.position == stumpWaypoint.transform.position) ;
        {
            state = BearState.calm;            
        }
    }

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
