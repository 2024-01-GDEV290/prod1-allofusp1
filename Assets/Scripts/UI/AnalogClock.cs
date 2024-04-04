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
        float currentHourAngle = this.GetComponent<RectTransform>().localEulerAngles.y;
        float newHourAngle = -360 * WindingTime.S.hours / 12f;
        if (newHourAngle < -720) { newHourAngle += 720; }

        StartCoroutine(MoveHrHand(currentHourAngle, newHourAngle));
        
        //this.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, hourAngle);
    }

    IEnumerator MoveHrHand(float currentHourAngle, float newHourAngle)
    {
        float angleDifference = newHourAngle - currentHourAngle + 360;

        for (int i = 0; i > angleDifference; i--)
        {
            currentHourAngle--;
            this.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, currentHourAngle);
            yield return new WaitForSeconds(hrHandDelay);
        }

        this.GetComponent<RectTransform>().localEulerAngles = new Vector3(0f, 0f, newHourAngle);
    }
}
