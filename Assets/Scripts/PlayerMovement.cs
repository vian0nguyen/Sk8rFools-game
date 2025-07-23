using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //OK so if we wanted to move Q using click interaction http://unity.grogansoft.com/move-player-to-clicktouch-position/

    public GameManager gm;

    private Rigidbody2D rb2d;
    public float XSpeed;
    public float YSpeed;
    public SpriteRenderer spriteRenderer;

    public Vector2 direction;
    public Vector2 Qdirection;

    public float velMag;
    //public int normalizedDir = 1; // positive is flipping as expected, negative is reversed <- Removed due to this causing issues where holding down up/down while moving right flips the sprite

    public Animator QAnim;

    PlayerPositionSave ppData;

    public enum playerStates{
        isWalking,
        isTalking,
        isFinishedTalking
    }
    public playerStates state;

 /* public void Awake()
    {
        ppData = FindObjectOfType<PlayerPositionSave>();
        ppData.PlayerPosLoad();
        Debug.Log("load player position");
    }*/
  
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();  
    }

    private void FixedUpdate()
    {
        //checks if the player is walking and then sets their walking velocity
        if(state == playerStates.isWalking){
            rb2d.velocity = new Vector2(direction.x * XSpeed, direction.y * YSpeed);
            velMag = rb2d.velocity.magnitude;
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        
        switch (state){
            case playerStates.isWalking:
                if (Input.GetKeyDown(KeyCode.Space)){ 
                    gm.dm.GetCurrentNPC().SetTalkingState();
                    state = playerStates.isTalking;
                    rb2d.velocity = Vector2.zero;
                }
                break;
            case playerStates.isTalking:
                if (Input.GetKeyDown(KeyCode.Space)){ 

                }
                break;
            case playerStates.isFinishedTalking:
                if (Input.GetKeyDown(KeyCode.Space)){
                    state = playerStates.isWalking;
                }
                break;
        }
        //else if (Input.GetKeyUp(KeyCode.Space)){ pressed = false; }
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

            if (direction.normalized.x > 0) spriteRenderer.flipX = false;
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

    void OnTriggerEnter2D(Collider2D col){

        if (col.gameObject.tag == "Item" && col.gameObject.TryGetComponent<InteractAnimationEvent>(out InteractAnimationEvent npc)){
            if (gm.dm.talkableNPCS.Contains(npc) == false)
            {
                gm.dm.talkableNPCS.Add(npc);
            }
            gm.dm.currentNPC = npc;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        
        if(col.gameObject.tag == "Item" && col.gameObject.TryGetComponent<InteractAnimationEvent>(out InteractAnimationEvent npc)){
            gm.dm.talkableNPCS.Remove(npc);
        }
    }
}
