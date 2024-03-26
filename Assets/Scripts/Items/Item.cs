using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public GameObject itemPrefab;
    public Sprite itemIcon;
    public bool held = false;
}
