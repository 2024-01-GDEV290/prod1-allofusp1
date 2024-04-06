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
    [SerializeField] protected AudioClip voice;
    [SerializeField] protected PlayerMotor player;
    [SerializeField] protected Actor actor;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected GameEventTrigger nextLineTrigger;
    [SerializeField] protected GameEventTrigger voiceTrigger;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<PlayerMotor>();
        actor = transform.parent.gameObject.GetComponent<Actor>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    protected void InitiateDialogue(string[] lines, List<GameEventTrigger> completionTriggers = null)
    {
        Dialogue.lines = lines;
        if (voiceTrigger != null) { Dialogue.voiceTrigger = voiceTrigger; }
        if (completionTriggers != null) Dialogue.completionTriggers = completionTriggers;
        nextLineTrigger.Raise();
    }

    public void Speak()
    {
        audioSource.pitch = Random.Range(.8f, 1.2f);
        audioSource.PlayOneShot(voice);
    }
    public abstract void CharacterBehavior();


}
