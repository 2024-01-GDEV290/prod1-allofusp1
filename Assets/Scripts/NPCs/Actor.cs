using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public enum RelativePlayerLocation
{
    Front,
    Back,
}
public class Actor : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] ScheduleEvent[] schedule;
    [SerializeField] float actorMoveSpd = 2f;
    public string displayName;
    //[SerializeField] Crank crank;
    [SerializeField] GameEventTrigger behaviorTrigger;
    [SerializeField] GameObject characterBody;

    [Header("Set Dynamically")]
    [SerializeField] ScheduleEvent currentScheduleEvent;
    [SerializeField] GameObject wayPoint;
    [SerializeField] public RelativePlayerLocation relativePlayerLocation;
    [SerializeField] float playerAngleFromForward = 0;
    [SerializeField] float playerAngleFromRight = 0;
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
        OrientSprite();
    }

    public void ReciteLines()
    {
        Debug.Log("Reciting Lines");
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

    void OrientSprite()
    {
        playerAngleFromForward = Vector3.Angle(Camera.main.transform.position - transform.position, transform.forward);
        playerAngleFromRight = Vector3.Angle(Camera.main.transform.position - transform.position, transform.right);
        if (playerAngleFromForward > 90)
        {
            relativePlayerLocation = RelativePlayerLocation.Back;
        }
        else
        {
            relativePlayerLocation = RelativePlayerLocation.Front;
        }

        if (playerAngleFromRight > 90)
        {
            characterBody.transform.localRotation = Quaternion.Euler(0, -playerAngleFromForward, 0);
        }
        else
        {
            characterBody.transform.localRotation = Quaternion.Euler(0, playerAngleFromForward, 0);
        }
        Debug.DrawRay(transform.position, transform.forward * 4, Color.red);
    }

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
