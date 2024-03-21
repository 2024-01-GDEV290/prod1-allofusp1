using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Actor : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] ScheduleEvent[] schedule;
    [SerializeField] float actorMoveSpd = 2f;
    public string displayName;
    //[SerializeField] Crank crank;
    [SerializeField] GameEventTrigger behaviorTrigger;


    [Header("Set Dynamically")]
    [SerializeField] ScheduleEvent currentScheduleEvent;
    [SerializeField] GameObject wayPoint;

    private void Awake()
    {
        if (displayName == null) displayName = gameObject.name;

    }

    private void Update()
    {
        if (wayPoint != null && wayPoint.transform.position != transform.position) 
        {
            // We should convert this movement system to use Navmesh eventually. 
            Vector3 newPosition = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * actorMoveSpd);
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position);
    }

    public void ReciteLines()
    {
        if(behaviorTrigger) behaviorTrigger.Raise();
    }

    public void MoveToScheduledLocation()
    {
        currentScheduleEvent = GetCurrentScheduleEvent();
        if (currentScheduleEvent != null)
        {
            wayPoint = GetWayPoint(currentScheduleEvent.wayPointName);   
        }
    }

/*    void OrientSprite()
    {
        Vector3 diff = Camera.main.transform.position - transform.position;
        if (Vector3.Angle(diff, transform.position) > 90)
        {
            // Orienting the decal to the correct direction so the particle system is facing towards the side the player is on. 
            decal.transform.localEulerAngles = new Vector3(-90, 0, 0);
        }
        else
        {
            decal.transform.localEulerAngles = new Vector3(90, 0, 0);
        }
    }*/

    GameObject GetWayPoint(string wayPointName)
    {
        return GameObject.Find(wayPointName);
    }

    ScheduleEvent GetCurrentScheduleEvent()
    {
        foreach (ScheduleEvent e in schedule)
        {
            if (WindingTime.S.hours >= e.startTime && WindingTime.S.hours < e.endTime) return e;
        }
        return null; 
    }
}
