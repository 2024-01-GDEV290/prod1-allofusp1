using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneComplete : MonoBehaviour
{
    [SerializeField] GameEventTrigger nextSceneTrigger;
    private void OnEnable()
    {
        TriggerNextSceneLoad();
    }
    void TriggerNextSceneLoad()
    {
        nextSceneTrigger.Raise();
    }
}
