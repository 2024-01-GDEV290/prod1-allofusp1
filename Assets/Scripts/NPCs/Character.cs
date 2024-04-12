using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Set In Inspector")]
    [SerializeField] protected AudioClip voice;
    [SerializeField] protected GameEventTrigger nextLineTrigger;
    [SerializeField] protected GameEventTrigger voiceTrigger;
    [SerializeField] protected int voiceFrequency = 3;
    [SerializeField] protected float voiceUpperPitchLimit = 1.2f;
    [SerializeField] protected float voiceLowerPitchLimit = .8f;
    [SerializeField] protected GameEventTrigger successSoundTrigger;
    [SerializeField] protected GameEventTrigger idleTrigger;


    protected SpriteRenderer spriteRenderer;
    protected AudioSource audioSource;
    protected PlayerMotor player;
    protected Actor actor;
    protected Animator animator;
    private int voiceCounter = 0;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<PlayerMotor>();
        actor = transform.parent.gameObject.GetComponent<Actor>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    protected void InitiateDialogue(string[] lines, List<GameEventTrigger> completionTriggers = null)
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(voice);
        voiceCounter = 0;
        Dialogue.lines = lines;
        if (voiceTrigger != null) { Dialogue.voiceTrigger = voiceTrigger; }
        if (completionTriggers != null) Dialogue.completionTriggers = completionTriggers;
        nextLineTrigger.Raise();
    }

    public void Speak()
    {

        if(voiceCounter % voiceFrequency == 0)
        {
            audioSource.pitch = Random.Range(voiceLowerPitchLimit, voiceUpperPitchLimit);
            audioSource.PlayOneShot(voice);
        }
        voiceCounter++;
    }
    public abstract void CharacterBehavior();

    protected void SetAnimation(string triggerID)
    {
        ResetAllTriggers();
        animator.SetTrigger(triggerID);
    }

    public void SetIdleAnimation()
    {
        SetAnimation("idle");
    }
    protected void ResetAllTriggers()
    {
        foreach (var param in animator.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                animator.ResetTrigger(param.name);
            }
        }
    }

    protected int CheckTime()
    {
        return WindingTime.S.hours;
    }

    protected void TriggerSuccessSound()
    {
        successSoundTrigger.Raise();
    }
}
