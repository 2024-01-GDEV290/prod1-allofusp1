using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonInteractiveBillboard : MonoBehaviour
{
    void LateUpdate()
    {
        OrientSprite();
    }

    void OrientSprite()
    {
        transform.localRotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
    }
}
