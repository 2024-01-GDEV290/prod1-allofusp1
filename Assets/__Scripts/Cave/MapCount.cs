using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapCount
{
	public static int mapsCollected = 0;
	public static int mapsNeeded = 3;

	public static bool map1Collected = false;
	public static bool map2Collected = false;
	public static bool map3Collected = false;

	public static void CheckMapCount()
	{
		if (mapsCollected >= mapsNeeded)
		{
			GlobalVars.hasMap = true;
			Debug.Log(GlobalVars.hasMap);
			Debug.Log("All maps collected. Return to sub.");
		}
	}
}
