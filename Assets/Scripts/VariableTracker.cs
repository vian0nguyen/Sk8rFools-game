using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class VariableTracker : MonoBehaviour
{
    public InkHandler IH;
    public int search;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        search = (int) IH.story.variablesState["checked"];
    }
}
