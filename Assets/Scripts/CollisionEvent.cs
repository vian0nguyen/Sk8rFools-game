using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    public bool interacted;
    public bool pressed;

    public bool inside;

    public InkHandler iH;

    //public TextAsset Blank;



    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && pressed == false) 
            { pressed = true; 
           

            if (pressed)
            {
                if (inside)
                {
                    if (interacted) //continue the story
                    {
                        iH.RefreshView();
                        Debug.Log("hey interaction!!");

                    }
                    else //new phone who dis
                    {
                        iH.Begin();
                        interacted = true;
                    }
                }

            }
            StartCoroutine("isPressed");
        }

    }

    IEnumerator isPressed ()
    {
        yield return new WaitForSeconds(.5f);
        pressed = false;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Item"))
        {
            iH.inkJSONAsset = collision.gameObject.GetComponent<ItemInk>().inkStory;
            inside = true;
            //theres prob a better fix for this?
            //get the component ink object of the colliding thingy

        }

        if (collision.gameObject.CompareTag("NPC"))
        {

            iH.inkJSONAsset = collision.gameObject.GetComponent<NPCInk>().inkStory;
            iH.textBoxNPC = collision.gameObject.GetComponent<NPCInk>().NPCTextBox;
            inside = true;
        }
        if (collision.gameObject.CompareTag("Clay"))
        {
            iH.inkJSONAsset = collision.gameObject.GetComponent<ItemInk>().inkStory;
            inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("Item"))
            {

                interacted = false;
                iH.inkJSONAsset = null; //turn it off!
                iH.ClearText(); //HELL YAAAA
                iH.RemoveChildren(); //still prints the next line wtf!!
                inside = false;      //theres prob a better fix for this?

            }
            if (collision.gameObject.CompareTag("NPC"))
            {
                interacted = false;
                iH.inkJSONAsset = null; //turn it off!
                iH.ClearText(); //HELL YAAAA
                iH.RemoveChildren(); //still prints the next line wtf!!
                inside = false;
            }

        if (collision.gameObject.CompareTag("Clay"))
        {
            interacted = false;
            iH.inkJSONAsset = null; //turn it off!
            iH.ClearText(); //HELL YAAAA
            iH.RemoveChildren(); //still prints the next line wtf!!
            inside = false;      //theres prob a better fix for this?
        }
    }

}
