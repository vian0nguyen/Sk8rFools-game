using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used for changes made to ALL NPCs
public class NPCManager : MonoBehaviour
{
    [SerializeField]
    InteractAnimationEvent[] npcs;

    //resets times interacted for ALL NPCs
    void ResetInteractedNPCs(){
        foreach(InteractAnimationEvent npc in npcs){
            npc.timesInteracted = 0;
        }
    }
}
