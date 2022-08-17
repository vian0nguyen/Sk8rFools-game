using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeSavePP : MonoBehaviour
{
    public GameObject player;
    public PlayerPositionSave ppSave;
    //public SpriteRenderer Select;
    public bool interacted;

    public string LoadScene;
    public PlayerPosition pp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (pp.checkpoint == true)
        {
            print("checked");
            player.transform.position = pp.newScene_Position;
            pp.checkpoint = false;  //dont work
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("collisiion works :thumbs up:");

        if (collision.gameObject.CompareTag("Player"))
        {
            if (interacted == false)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene(LoadScene);

                    interacted = true;
                    pp.checkpoint = true;
                    print("this this happening");
                    //pp.checkpoint = false;

                    
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interacted = false;
        }
    }
}
