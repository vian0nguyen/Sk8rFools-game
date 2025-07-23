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

    public enum itemsCheck
    {

    }

    private void Awake()
    {
        questDict = new Dictionary<string, QuestScript>();

        foreach (QuestScript quest in quests)
        {
            questDict.Add(quest.questInfo.questID, quest);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //IH.story.variablesState["player_health"] = 100;

        
    }

    private void Update()
    {
        //health = (int)IH.story.variablesState["player_health"];
    }
    
    //syncs quest dictionary with displayed quests
    public void UpdateQuestDict(){
        foreach (QuestScript quest in quests)
        {
            questDict[quest.questInfo.questID].status = quest.status;
        }
    }

    //functions for starting/progressing/completing quests (written here because each quest might have different stuff triggered when those events happen
    public void StartQuest(string questID)
    {
        questDict[questID].QuestStart();
    }

    public void ProgressQuest(string questID)
    {
        questDict[questID].ProgressQuest();
    }

    public void CompleteQuest(string questID)
    {
        questDict[questID].QuestComplete();
    }
}