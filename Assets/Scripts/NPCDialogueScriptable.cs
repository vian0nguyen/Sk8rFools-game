using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/NPCDialogueScriptable")]
public class NPCDialogueScriptable : ScriptableObject
{
    [System.Serializable]
    public struct DialogueArc{
        [SerializeField]
        public TextAsset[] progressiveDialogueItems;
        [SerializeField]
        public TextAsset repeatingDialogueItem;
    }
    [SerializeField]
    public DialogueArc[] dialogueArcs;
}
