using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTransition : MonoBehaviour
{
    public Animator transition;
    private void Awake()
    {
        transition = GetComponent<Animator>();
    }
    public void FadeIn()
    {
        transition.ResetTrigger("In");
        transition.ResetTrigger("Out");
        transition.SetTrigger("In");
    }

    public void FadeOut() {
        transition.ResetTrigger("In");
        transition.ResetTrigger("Out");
        transition.SetTrigger("Out");
    }

}
