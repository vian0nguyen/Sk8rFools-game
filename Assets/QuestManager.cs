using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;


public class QuestManager : MonoBehaviour
{
    public InkHandler IH;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        IH.story.variablesState["player_health"] = 100;

        
    }

    private void Update()
    {
        //health = (int)IH.story.variablesState["player_health"];
    }
}

