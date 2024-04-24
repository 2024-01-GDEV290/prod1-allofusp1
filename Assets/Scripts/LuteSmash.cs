using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuteSmash : MonoBehaviour
{
    [SerializeField] private GameObject Smasher;
    [SerializeField] private GameObject idel;
    [SerializeField] private NPCInteraction npcStuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(npcStuff.dialogueManager.readOnce)
        {
            npcStuff.interactionText.SetActive(false);
            npcStuff.transitionCamera.SetActive(true);
            Smasher.SetActive(true);
            idel.SetActive(false);
        }

    }
}
