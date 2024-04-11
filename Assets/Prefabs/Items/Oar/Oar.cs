using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oar : MonoBehaviour
{
    [SerializeField] private int lowTideHr;

    public void LayerCheck()
    {
        int[] lowTides = new int[6];
        lowTides[0] = lowTideHr;
        lowTides[1] = lowTideHr - 1;
        lowTides[2] = lowTideHr + 1;
        lowTides[3] = lowTideHr + 12;
        lowTides[4] = lowTideHr + 11;
        lowTides[5] = lowTideHr + 13;

        int i = 0;
        bool lowTide = false;

        while ((i<6) && !lowTide)
        {
            if (lowTides[i] < 0) { lowTides[i] += 12; }
            else if (lowTides[i] >= 24) { lowTides[i] -= 12; }

            if (WindingTime.S.hours == lowTides[i])
            {
                gameObject.layer = 6;
                lowTide = true;
            }

            else
            {
                gameObject.layer = 0;
            }
        }
    }
}
