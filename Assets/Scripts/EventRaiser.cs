using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(GameEventTrigger))]
public class EventRaiser : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameEventTrigger eventTrig = (GameEventTrigger)target;

        if (GUILayout.Button("Raise()"))
        {
            eventTrig.Raise();
        }
    }
}
