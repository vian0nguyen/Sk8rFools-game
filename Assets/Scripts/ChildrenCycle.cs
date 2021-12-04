using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenCycle : MonoBehaviour
{
    public int arrayCount;
    public int arrayLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("down");
            RetrieveChildren();

            // Step to next position in array
            arrayCount++;

            // If Array count excedes Array index then go back to first position in array
            if (arrayCount >= arrayLimit)
            {
                arrayCount = 0;
            }
        }
    }

    public void RetrieveChildren()
    {
        Debug.Log(transform.childCount);
        int i = 0;
        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
            arrayCount = i;
        }
        Debug.Log(transform.childCount);
    }
}
