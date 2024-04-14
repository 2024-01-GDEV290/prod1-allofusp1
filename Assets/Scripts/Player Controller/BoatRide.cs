using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRide : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private string boatAnimBoolName;
    [SerializeField] Transform playerAnchor;

    public GameEventTrigger sailStart;
    public GameEventTrigger sailEnd;
    public float animationTime;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetSail()
    {
        player.transform.SetParent(playerAnchor, true);
        player.transform.position = playerAnchor.position;
        player.GetComponent<CharacterController>().enabled = false;
        anim.SetBool(boatAnimBoolName, true);
        sailStart.Raise();
        Invoke("Disembark", animationTime);
    }

    private void Disembark()
    {
        sailEnd.Raise();
        player.GetComponent<CharacterController>().enabled = true;
        player.transform.SetParent (null);
    }
}
