using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    private void Start()
    {
        UpdateClock();
    }

    public void UpdateClock()
    {
        float currentHourAngle = this.GetComponent<RectTransform>().localEulerAngles.z;
        if (currentHourAngle > 0) { currentHourAngle -= 360; }

        int newHour = WindingTime.S.hours;
        if (newHour > 12) { newHour -= 12; }
        else if (newHour == 0) { newHour = 12; }

        float newHourAngle = -360 * newHour / 12f;
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
            yield return new WaitForSeconds(1/1000f);
        }

        this.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, newHourAngle);
    }
}
