using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used for things that STAY STATIC throughout the game (if you need quest status, look up the quest script)
[CreateAssetMenu(menuName = "ScriptableObjects/NPCDialogueScriptable")]
public class QuestInfoScriptable : ScriptableObject
{
    public string questID;
}
