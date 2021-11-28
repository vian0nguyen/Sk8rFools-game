using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //OK so if we wanted to move Q using click interaction http://unity.grogansoft.com/move-player-to-clicktouch-position/

    private Rigidbody2D rb2d;
    public float XSpeed;
    public float YSpeed;
    public SpriteRenderer spriteRenderer;

    public Vector2 direction;
    public Vector2 Qdirection;

    public float velMag;
    public int normalizedDir = 1; // positive is flipping as expected, negative is reversed

    public Animator QAnim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
    }

    private void FixedUpdate()
    {
        
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * XSpeed, Input.GetAxis("Vertical") * YSpeed);
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        velMag = rb2d.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {

        Anim();
        Flip();
        //VertMove();           //animation doesnt play if x stays the same

        Qdirection = transform.position; //being used for clay's flip script!
    }

    public void Flip() //flips sprite renderer
    {
        if (direction.normalized.x != 0)
        {
            //QAnim.SetBool("isWalking", true);

            if (direction.normalized.x == normalizedDir) spriteRenderer.flipX = false;
            else spriteRenderer.flipX = true;
        }
       //else QAnim.SetBool("isWalking", false);


    }
    public void Anim()
    {
        if(velMag != 0)
        {
            QAnim.SetBool("isWalking", true);
            if (direction.normalized.y == 0 && direction.normalized.x == 0) {
              
                    QAnim.SetBool("isWalking", false);
                   

                    //goes when player is standing still AND with weird bug
                    //    //if player presses a directional key and presses the
                    //    //opposing direction, character will slide
                    //forcing velMag = 0 is not a fix!
                    //it looks like a direction axis issue


            }

        }
        else QAnim.SetBool("isWalking", false);


    }
}
