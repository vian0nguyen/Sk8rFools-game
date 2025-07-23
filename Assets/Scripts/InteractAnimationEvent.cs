using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractAnimationEvent : MonoBehaviour
{
    public GameObject player;
    //public SpriteRenderer Select;
    public bool interacted;
    public Animator SparkAnim;
    public Animator ItemAnim;
    //make a thing for NPC talking anim?? 

    public NPCDialogueScriptable dialogueScriptable;
    public int timesInteracted = 0;

    public TMP_Text textBox;

    public bool isItem;

    //move all interaction stuff to player input script

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Select = GameObject.FindGameObjectWithTag("Select").GetComponent<SpriteRenderer>();
        //Select = gameObject.GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collisiion works :thumbs up:");

        if (collision.gameObject.CompareTag("Player"))
        {
            if (interacted == false)
            {
                SparkAnim.SetBool("isHover", true);

            }
        }

    }
    /*void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("collisiion works :thumbs up:");

        if (collision.gameObject.CompareTag("Player"))
        {
            if (interacted == false)
            {
                SparkAnim.SetBool("isHover", true);
                if (pressed==true)//DID U KNO? input needs to happen in update or else it fucky
                {
                 
                }
            }
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SparkAnim.SetBool("isInteract", false);
            SparkAnim.SetBool("isHover", false);
            if (isItem == true)
            {
                ItemAnim.SetBool("isInteract", false);
            }
            interacted = false;
        }
    }

    public void SetTalkingState(){
         //  Debug.Log("pressing stop in stay");
        SparkAnim.SetBool("isInteract", true);
        if (isItem == true)
        {
            ItemAnim.SetBool("isInteract", true);
        }
        timesInteracted++;
    }
}
