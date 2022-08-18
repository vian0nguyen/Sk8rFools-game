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
        sprites = new List<SpriteRenderer>();
        RetrieveChildren();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("down " + arrayCount);
            ChildrenCycler();

            // Step to next position in array
            arrayCount++;

            // If Array count excedes Array index then go back to first position in array
            if (arrayCount >= arrayLimit)
            {
                //print("restart");
                arrayCount = 0;
            }
        }
    }

    //only number finder
    public void RetrieveChildren()
    {
        
        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];
        arrayLimit = transform.childCount;
        //Find all child obj and store to that array
        for (int i = 0; i < arrayLimit; i++)
        {
            //just numbers
            allChildren[i] = transform.GetChild(i).gameObject;//child.gameObject;
            arrayCount = i;
            print(allChildren[i].name);

        }

        //the sprite renderer finder
        //BUG its re-getting index 0
        foreach (GameObject hats in allChildren)
        {
            //just sprite finder
            var renderer = hats.GetComponent<SpriteRenderer>();
            
            //Add it to the list if its a child and has the component
            if (renderer)
            {
                print("sprite added");
                sprites.Add(renderer);
            }
        }

        //Debug.Log("I found this many " + transform.childCount);
    }

    public void ChildrenCycler()
    {
        foreach (SpriteRenderer child in sprites)//turn off not selected
        {
            child.enabled = false; //hide all children
        }

        sprites[arrayCount].enabled = true; //turns on the current 
        
    }
}
