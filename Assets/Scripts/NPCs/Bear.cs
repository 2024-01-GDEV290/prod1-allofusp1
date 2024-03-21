using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] List<Item> inventory;
    [SerializeField] PlayerMotor player;
    [SerializeField] Item desiredItem;
    [TextArea][SerializeField] string satisfiedDialogue;
    [SerializeField] GameEventTrigger openGateTrigger;
    [SerializeField] Actor actor;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMotor>();
        actor = GetComponent<Actor>();
    }
    public void CharacterBehavior()
    {
        if (desiredItem && player.currentlyHeldItem && player.currentlyHeldItem.GetComponent<ItemAvatar>().item == desiredItem)
        {
            Debug.Log(satisfiedDialogue);
            TakeItem();
            openGateTrigger.Raise();
            return;
        }
    }

    void TakeItem()
    {
        player.DropItem();
    }
}
