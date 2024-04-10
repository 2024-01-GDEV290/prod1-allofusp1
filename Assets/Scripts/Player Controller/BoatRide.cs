using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRide : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private string boatAnimBoolName;

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
        player.transform.SetParent(transform, true);
        anim.SetBool(boatAnimBoolName, true);
        sailStart.Raise();
        Invoke("Disembark", animationTime);
    }

    private void Disembark()
    {
        sailEnd.Raise();
    }
}
