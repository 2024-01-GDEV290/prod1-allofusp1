using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : Prop
{
    [SerializeField] Item requiredItem;
    [SerializeField] GameEventTrigger trigger;
    public override void Behavior()
    {
        if (requiredItem == player.currentlyHeldItem.GetComponent<ItemAvatar>().item)
        {
            player.DropItem();
            trigger.Raise();
        }
    }
}
