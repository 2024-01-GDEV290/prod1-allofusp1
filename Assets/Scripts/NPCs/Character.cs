using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CharacterState{
    idle,
    walking
}
public abstract class Character : MonoBehaviour
{
    [TextArea]
    [SerializeField] protected string defaultDialogue;

    [SerializeField] protected PlayerMotor player;
    [SerializeField] protected Actor actor;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected AudioClip[] defaultInteractSounds;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected GameEventTrigger nextLineTrigger;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<PlayerMotor>();
        actor = transform.parent.gameObject.GetComponent<Actor>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    protected void InitiateDialogue(string[] lines)
    {
        Dialogue.lines = lines;
        nextLineTrigger.Raise();
    }
    public abstract void CharacterBehavior();


}
