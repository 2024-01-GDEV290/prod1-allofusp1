using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneComplete : MonoBehaviour
{
    [SerializeField] GameEventTrigger nextSceneTrigger;

    private void Start()
    {
        Invoke(nameof(TriggerNextSceneLoad), 30);
    }

    // TODO:Fix activation track in timeline
    /*    private void OnEnable()
        {
            TriggerNextSceneLoad();
        }*/
    void TriggerNextSceneLoad()
    {
        nextSceneTrigger.Raise();
    }
}
