using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : Prop
{
    [SerializeField] Item requiredItem;
    [SerializeField] GameEventTrigger successTrigger;
    public override void Behavior()
    {
        if (requiredItem == player.currentlyHeldItem.GetComponent<ItemAvatar>().item)
        {
            float ripeness = player.currentlyHeldItem.GetComponent<AppleTime>().ripeness;
            Debug.Log(ripeness);
            if (ripeness >= .5f && ripeness<= .6f)
            {
                player.DropItem();
                successTrigger.Raise();
            }

        }
    }
}
