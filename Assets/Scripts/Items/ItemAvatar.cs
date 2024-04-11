using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAvatar : MonoBehaviour
{
    public Item item;

    public Item Collect(Transform newParentTransform = null)
    {
        if (newParentTransform != null)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(newParentTransform, false);
            transform.localPosition = item.heldPosition;
            transform.localRotation = Quaternion.Euler(item.heldRotation.x,item.heldRotation.y,item.heldRotation.z);
            transform.localScale = item.heldScale;
        }
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }
        return item;
    }
}
