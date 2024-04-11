using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    [SerializeField] [Range(0f, 0.1f)] float hrHandDelay;

    private void Start()
    {
        UpdateClock();
    }

    public void UpdateClock()
    {
        float currentHourAngle = this.GetComponent<RectTransform>().localEulerAngles.z;
        int newHour = WindingTime.S.hours;
        if (newHour >= 12) { newHour -= 12; }
        float newHourAngle = -360 * newHour / 12f + 360;
        //if (newHourAngle <= -360) { newHourAngle += 360; }

        StartCoroutine(MoveHrHand(currentHourAngle, newHourAngle));
        
        //this.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, hourAngle);
    }

    IEnumerator MoveHrHand(float currentHourAngle, float newHourAngle)
    {
        float angleDifference = newHourAngle - currentHourAngle;

        for (int i = 0; i > angleDifference; i--)
        {
            currentHourAngle--;
            this.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, currentHourAngle);
            yield return new WaitForSeconds(hrHandDelay);
        }

        this.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, newHourAngle);
    }
}
