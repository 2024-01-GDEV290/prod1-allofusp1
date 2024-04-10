using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingAreaGate : MonoBehaviour
{
    [SerializeField] private string gateBoolName;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        //gameObject.SetActive(false);
        anim.SetBool(gateBoolName, true);
    }
}
