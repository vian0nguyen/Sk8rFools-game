using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAnimationEvent : MonoBehaviour
{
    public GameObject player;
    //public SpriteRenderer Select;
    public bool interacted;
    public bool pressed;
    public Animator SparkAnim;
    public Animator ItemAnim;
    //make a thing for NPC talking anim?? 

    public bool isItem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Select = GameObject.FindGameObjectWithTag("Select").GetComponent<SpriteRenderer>();
        //Select = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){ pressed = true; }
        else if (Input.GetKeyUp(KeyCode.Space)){ pressed = false; }
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
    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("collisiion works :thumbs up:");

        if (collision.gameObject.CompareTag("Player"))
        {
            if (interacted == false)
            {
                SparkAnim.SetBool("isHover", true);
                if (pressed==true)//DID U KNO? input needs to happen in update or else it fucky
                {
                  //  Debug.Log("pressing stop in stay");
                    SparkAnim.SetBool("isInteract", true);
                    if (isItem == true)
                    {
                        ItemAnim.SetBool("isInteract", true);
                    }
                    interacted = true;
                }
            }
        }
    }


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
}
