using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapCount
{
	public static int mapsCollected = 0;
	public static int mapsNeeded = 3;
	
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
