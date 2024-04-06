using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gear : MonoBehaviour
{
    [SerializeField] float spinRate = 10.0f;
    [SerializeField] bool reverseSpin = false;

    private void FixedUpdate()
    {
        float amount = (reverseSpin ? -1 : 1) * (spinRate * Time.deltaTime);
        transform.RotateAround(transform.position, transform.right, amount);
    }
}

