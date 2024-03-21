using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [TextArea]
    [SerializeField] protected string defaultDialogue;

    [SerializeField] protected PlayerMotor player;
    [SerializeField] protected Actor actor;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMotor>();
        actor = GetComponent<Actor>();
    }
    public abstract void CharacterBehavior();


}
