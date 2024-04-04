using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tide : MonoBehaviour
{
    [SerializeField] private int lowTideHr;
    [SerializeField] private string animationName;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeTide()
    {
        int tideTime = WindingTime.S.hours - lowTideHr;

        if (tideTime < 0) { tideTime += 24; }

        float cycle = tideTime / 24f;

        anim.Play(animationName, 0, cycle);
    }
}
