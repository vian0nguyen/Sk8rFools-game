using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenCycle : MonoBehaviour
{
    public int arrayCount;
    public int arrayLimit;
    public int i = 0;

    public List<SpriteRenderer> sprites;

    private void Start()
    {
        RetrieveChildren();
        

        sprites = new List<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("down " + arrayCount);
            ChildrenCycler();

            // Step to next position in array
            arrayCount++;

            // If Array count excedes Array index then go back to first position in array
            if (arrayCount > arrayLimit)
            {
                Debug.Log("too many!");
                arrayCount = 0;
            }
        }
    }

    public void RetrieveChildren()
    {
        //only number finder
        //int i = 0; //i think initiallizing i inside the function is setting it to always equal 0
        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];
        arrayLimit = transform.childCount;

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            //just numbers
            allChildren[i] = child.gameObject;
            arrayCount = i;
            

        }
        //the sprite finder
        // SpriteRenderer sprites = GetComponentInChildren<SpriteRenderer>();
        foreach (SpriteRenderer child in sprites)
        {
            //just sprite finder
            var renderer = sprites[i].GetComponent<SpriteRenderer>();
            
            //Add it to the list if it does
            if (renderer)
            {
                sprites.Add(renderer);
            }
        }
        Debug.Log("I found this many " + transform.childCount);
    }

    public void ChildrenCycler()
    {
        foreach (SpriteRenderer child in sprites)//turn off not selected
        {
            child.enabled = false; //?
        }

        sprites[arrayCount].enabled = true; //turns on the current selected
                                            //var renderer = sprites[i].GetComponent<SpriteRenderer>();
                                            //  sprites[arrayCount].enabled = true;
        
        
    }
}
