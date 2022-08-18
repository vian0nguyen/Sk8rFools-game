using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject follower;
    public GameManager gm;
 
    public bool interacted;
    public PlayerPosition playerPos;
    public PlayerPosition followPos;
    public Vector2 playerCoord;
    public Vector2 followCoord;

    public CinemachineVirtualCamera prevcam, newcam;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        follower = GameObject.FindGameObjectWithTag("Clay");
        gm = GameObject.FindObjectOfType<GameManager>();


    }
   

    public void PrioritySwitch()
    {
        if (gm.overworldCam == true)
        {
            prevcam.Priority = 0;
            newcam.Priority = 1;
            
        }
        else if (gm.overworldCam == false)
        {
            newcam.Priority = 0;
            prevcam.Priority = 1;
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            
                if (Input.GetKey(KeyCode.Space))
                {
                    //print("interaction is" + interacted);
                    gm.Transition();

                //gm.SwitchPriority();
                PrioritySwitch();
                print("overworld cam is " + gm.overworldCam); //only trueFalses when leaving KT store???


                //change this to set player position to new position
                playerCoord = new Vector2(playerPos.newScene_Position.x, playerPos.newScene_Position.y);
                followCoord = new Vector2(playerPos.newScene_Position.x + 2, playerPos.newScene_Position.y); //add two so clay is standing next to Q
                player.transform.position = new Vector2(playerCoord.x, playerCoord.y);
                follower.transform.position = new Vector2(followCoord.x, followCoord.y);
                //need to add trasnform for clay
  
                }
                // interacted = !interacted;
      
        }
    }
}
