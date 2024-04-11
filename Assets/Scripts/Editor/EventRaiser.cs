using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEventTrigger))]
public class EventRaiser : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        GameEventTrigger eventTrig = (GameEventTrigger)target;

        if (GUILayout.Button("Raise()"))
        {
            eventTrig.Raise();
        }
    }
}
