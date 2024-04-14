using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bird : Character
{
    [Header("Set in inspector")]
    [SerializeField] private GameEventTrigger embark;
    
    public override void CharacterBehavior()
    {
        SetAnimation("flap");
        embark.Raise();
    }
}
