using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class VariableTracker : MonoBehaviour
{
    public InkHandler IH;
    public string name;
    public int search;

    
    void Update()
    {
        //how are we gonna decide what knots to show?
        //maybe we call them in scene changes?
       
            IH.knotName = name;
        
    }
}
