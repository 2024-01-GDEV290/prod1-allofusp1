using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gear : MonoBehaviour
{
    [SerializeField] float spinRate = 10.0f;

    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, transform.right, spinRate * Time.deltaTime);
    }
}

