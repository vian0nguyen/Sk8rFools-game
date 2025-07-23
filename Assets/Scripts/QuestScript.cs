using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//quest states are changed via tags in ink
public class QuestScript : MonoBehaviour
{
    [SerializeField]
    private QuestManager qm;

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

    public virtual void QuestStart()
    {
        status = questStatus.InProgress;
        OnQuestStart.Invoke();
        qm.UpdateQuestDict();
    }

    public virtual void ProgressQuest()
    {
        OnQuestProgress.Invoke();
        qm.UpdateQuestDict();
    }

    public virtual void QuestComplete(){
        status = questStatus.Complete;
        OnQuestComplete.Invoke();
        qm.UpdateQuestDict();
        gameObject.SetActive(false);
    }

    public virtual void QuestCompleteCheckTrue()
    {

    }
    
    public virtual void QuestCompleteCheckFalse()
    {

    }
}
