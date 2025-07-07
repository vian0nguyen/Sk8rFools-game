using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameManager gm;
    public InteractAnimationEvent currentNPC;

    public List<InteractAnimationEvent> talkableNPCS;

    //function for picking out dialogue based on what arc we're on
    public TextAsset ChooseArcDialogue(int timesInteracted){
        if (gm.arc < currentNPC.dialogueScriptable.dialogueArcs.Length){
            return ChooseProgressionDialogue(currentNPC.dialogueScriptable.dialogueArcs[gm.arc], timesInteracted);
        }

        else{
            int lastItem = currentNPC.dialogueScriptable.dialogueArcs.Length - 1;
            return ChooseProgressionDialogue(currentNPC.dialogueScriptable.dialogueArcs[lastItem], timesInteracted);
        }
    }

    //function for picking out dialogue based on how many times you've interacted with this npc in this arc
    public TextAsset ChooseProgressionDialogue(NPCDialogueScriptable.DialogueArc arc, int timesInteracted){
        if(currentNPC.timesInteracted < arc.progressiveDialogueItems.Length){
            return arc.progressiveDialogueItems[timesInteracted];
        }
        else{
            return arc.repeatingDialogueItem;
        }
    }

    public void SetUpDialogue (InteractAnimationEvent interactScript) {
        
        if(interactScript.dialogueScriptable != null || interactScript.dialogueScriptable.dialogueArcs.Length == 0){
            currentNPC = interactScript;
            //connect dialogue display to here and use choose arc dialogue
        }
    }

    public InteractAnimationEvent GetCurrentNPC(){
        if (talkableNPCS.Count < 1){
            Debug.LogError("Please be in range of an npc");
            return null;
        }
        else {
            return talkableNPCS[talkableNPCS.Count-1];
        }
    }
}
