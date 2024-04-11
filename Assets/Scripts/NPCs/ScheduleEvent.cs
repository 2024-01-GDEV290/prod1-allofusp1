using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScheduleEvent : ScriptableObject
{
    public string wayPointName;

    public float startTime; //Times are represented as rotation values for now. 
    public float endTime;
}
