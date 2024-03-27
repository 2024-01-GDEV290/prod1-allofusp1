using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Prop : MonoBehaviour
{
    [SerializeField] protected PlayerMotor player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMotor>();
    }
    public abstract void Behavior();
}
