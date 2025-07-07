using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.Events;


public class QuestManager : MonoBehaviour
{
    public InkHandler IH;
    public int health;

    //this is the main reference to whether a quest is complete or not and to update the quest
    public Dictionary <string, QuestScript> questDict;
    //TODO: add tag that checks if a certain quest is complete 

    [SerializeField]
    public QuestScript[] quests;

    // Start is called before the first frame update
    void Start()
    {
        IH.story.variablesState["player_health"] = 100;

        
    }

    private void Update()
    {
        //health = (int)IH.story.variablesState["player_health"];
    }

    public virtual void UpdateQuest(string questID, QuestScript.questStatus status){
        UpdateQuestDict();
    }
    
    //syncs quest dictionary with displayed quests
    public void UpdateQuestDict(){
        foreach (QuestScript quest in quests)
        {
            questDict[quest.questID].status = quest.status;
        }
    }
}