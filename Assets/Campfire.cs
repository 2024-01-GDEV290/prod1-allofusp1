using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    [SerializeField] int nightStartTime = 18;
    [SerializeField] int nightEndTime = 5;
    [SerializeField] GameObject fire;
    int currentTime;
    // Start is called before the first frame update

    private void LateUpdate()
    {
        OrientSprite();
    }
    void OrientSprite()
    {
        fire.transform.localRotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
    }
    public void FireBehavior()
    {
        currentTime = CheckTime();
        if (CheckTime() >= nightStartTime || CheckTime() <= nightEndTime)
        {
            fire.SetActive(true);
        } else
        {
            fire.SetActive(false);
        }
    }
    int CheckTime()
    {
        return WindingTime.S.hours;
    }
}
