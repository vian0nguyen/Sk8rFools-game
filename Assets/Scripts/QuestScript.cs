using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//quest states are changed via tags in ink
public class QuestScript : MonoBehaviour
{
    [HideInInspector]
    public QuestManager qm;

    public QuestInfoScriptable questInfo;
    public enum questStatus{
        NotStarted,
        InProgress,
        Complete
    }
    public questStatus status;

    public UnityEvent OnQuestStart;
    public UnityEvent OnQuestProgress;
    public UnityEvent OnQuestComplete;

    public virtual void CheckQuestCompletion(string questID){

    }

    public void QuestStart()
    {
        OnQuestStart.Invoke();
    }

    public void ProgressQuest()
    {
        OnQuestProgress.Invoke();
    }

    public void QuestComplete(){
        OnQuestComplete.Invoke();
        gameObject.SetActive(false);
    }
}
