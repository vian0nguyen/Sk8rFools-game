using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    [HideInInspector]
    public QuestManager qm;

    public string questID;
    public enum questStatus{
        NotStarted,
        InProgress,
        Complete
    }
    public questStatus status;

    public virtual void CheckQuestCompletion(string questID){

    }

    void OnQuestComplete(){
        Destroy(this.gameObject);
    }
}
