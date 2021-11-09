using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayFollow : MonoBehaviour
{//SOURCE: https://www.youtube.com/watch?v=rhoQd6IAtDo
    public float Speed = 4;
    public float DistancetoStop;
    public Transform target;
    public SpriteRenderer spriteRenderer;

    //sIGHHHH SOURCE: https://stackoverflow.com/questions/28320177/get-gameobject-last-and-current-transform-position-from-script
    // public Vector3 lastPosition;   //part of a inprog solution
    // public Vector3 currentPosition;   //part of a inprog solution
    public Vector2 direction;
    public PlayerMovement pmovement;

    public bool isWalk;

    public Animator ClayAnim;

    void Start()
    {
        //lastPosition = transform.position;    //part of a inprog solution

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        pmovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //currentPosition = transform.position;   //part of a inprog solution
        direction = transform.position;

        if (isWalk)
        {
            ClayAnim.SetBool("isWalking", true);
        }
        else ClayAnim.SetBool("isWalking", false);

        Follow();
        if ((pmovement.Qdirection.x - direction.x) != 0)        
        {
            Flip();
        }
        if ((pmovement.Qdirection.y - direction.y) != 0)
        {
            Order();
        }


        // lastPosition = transform.position;   //part of a inprog solution
    }

    void Follow()
    {
        //follow target

        if (Vector2.Distance(transform.position, target.position) > DistancetoStop)
        {
            //works but is super glitchy looking !! SCREAMS !! 
            //FIX : in the animation transition, change interruption source to: next state

            isWalk = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }

        else isWalk = false;      //test to see if it just rapidly sends to false again

    }

    void Flip() //checks q's position to see if clay should flip
    {


            if ((pmovement.Qdirection.x - direction.x) >= 0)
            {
                spriteRenderer.flipX = false;
            }
             else
             {
                spriteRenderer.flipX = true;
            }

    }


    public void Order()//check's if one is behind or in front and changes the order in layer
    {//gotta make a function vers of this but for all objects in q and clay's area of effect
     
        if ((pmovement.Qdirection.y - direction.y) >= 0)
            {

                spriteRenderer.sortingOrder = 11;
            }
            else
            {
                spriteRenderer.sortingOrder = 9; 
            }
            
        }
}