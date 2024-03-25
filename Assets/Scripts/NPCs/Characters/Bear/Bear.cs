using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Character
{
    [SerializeField] List<Item> inventory;
    [SerializeField] Item desiredItem;
    [TextArea][SerializeField] string satisfiedDialogue;
    [SerializeField] GameEventTrigger openGateTrigger;



    public override void CharacterBehavior()
    {
        if (desiredItem && player.currentlyHeldItem && player.currentlyHeldItem.GetComponent<ItemAvatar>().item == desiredItem)
        {
            Debug.Log(satisfiedDialogue);
            TakeItem();
            openGateTrigger.Raise();
            return;
        }
        else
        {
            Debug.Log(defaultDialogue); 
        }
    }

    void TakeItem()
    {
        player.DropItem();
    }
}
