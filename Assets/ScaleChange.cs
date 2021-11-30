using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    public float limit;
    public float scale;

    public float scaleChange;

    public PlayerMovement pMove; //might not need this if curr and change pos works

    // Start is called before the first frame update
    void Start()
    {
        pMove = GetComponent<PlayerMovement>();

    }

    private void FixedUpdate()
    {
        scaleChange = (transform.position.y - limit) * -scale;
        transform.localScale = new Vector3(scaleChange, scaleChange, transform.localScale.z);
    }
    //TODO:
    //currently this solution is mega jank
    //need to find a cleaner way to map position to a toit scale range

    // Update is called once per frame
    /*void Update()
    {
        if (pMove.walk == true) 
        {
            if (tran.transform.position.y < 0f)
            {
                //when position is less than 0
                //or closer to the foreground
                //the object gets bigger
                gameObject.transform.localScale += scaleChange; 
            }
            else if (tran.transform.position.y > 0f)
            {
                //if the position is greater than 0
                //or further from the foreground
                //the object (should) get smaller
                gameObject.transform.localScale -= scaleChange;
            }
        }*/




}
