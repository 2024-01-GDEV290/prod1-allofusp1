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
    [SerializeField] protected NPCSpriteManager spriteManager;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected AudioClip[] defaultInteractSounds;
    [SerializeField] protected AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<PlayerMotor>();
        actor = transform.parent.gameObject.GetComponent<Actor>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    private void LateUpdate()
    {
        if (actor.relativePlayerLocation == RelativePlayerLocation.Back && spriteRenderer.sprite != spriteManager.backIdle)
        {
            spriteRenderer.sprite = spriteManager.backIdle;
        }else if (actor.relativePlayerLocation == RelativePlayerLocation.Front && spriteRenderer.sprite != spriteManager.frontIdle)
        {
            spriteRenderer.sprite = spriteManager.frontIdle;
        }
    }
    public abstract void CharacterBehavior();


}
