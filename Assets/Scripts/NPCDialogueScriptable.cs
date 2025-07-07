using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/NPCDialogueScriptable")]
public class NPCDialogueScriptable : ScriptableObject
{
    public struct DialogueArc{
        public TextAsset[] progressiveDialogueItems;
        public TextAsset repeatingDialogueItem;
    }

    public DialogueArc[] dialogueArcs;
}
