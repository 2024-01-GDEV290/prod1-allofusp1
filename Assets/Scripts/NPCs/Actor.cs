using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Actor : MonoBehaviour
{
    [Header("Set in Inspector")]
    public string displayName;
    //[SerializeField] Crank crank;
    [SerializeField] GameEventTrigger behaviorTrigger;
    [SerializeField] GameObject characterBody;

    [Header("Set Dynamically")]
    [SerializeField] NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (displayName == null) displayName = gameObject.name;
    }

    private void LateUpdate()
    {
        OrientSprite();
    }

    public void ReciteLines()
    {
        if(behaviorTrigger) behaviorTrigger.Raise();
    }

    public void MoveToWaypoint(Transform wayPoint)
    {
        agent.destination = wayPoint.position;
    }

    float PlayerAngleFromForward()
    {
        return Vector3.Angle(Camera.main.transform.position - transform.position, transform.forward);
    }

    float PlayerAngleFromRight()
    {
        return Vector3.Angle(Camera.main.transform.position - transform.position, transform.right);
    }

    void OrientSprite()
    {
        characterBody.transform.localRotation = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y, 0);
        Debug.DrawRay(transform.position, transform.forward * 4, Color.red);
    }
}
