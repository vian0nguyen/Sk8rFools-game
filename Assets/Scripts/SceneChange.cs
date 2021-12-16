using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject player;
    public PlayerPositionSave ppSave;
    //public SpriteRenderer Select;
    public bool interacted;

    public string LoadScene;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ppSave = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPositionSave>();

        //Select = GameObject.FindGameObjectWithTag("Select").GetComponent<SpriteRenderer>();
        //Select = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (ppSave == null) //this aint workin lol wont set the component when switching scenes? or when in a different scene
        {
            ppSave = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPositionSave>();
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
                    Debug.Log("saving bro");
                    ppSave.PositionSave();
                    Debug.Log("space to enter door");
                    SceneManager.LoadScene(LoadScene);

                    interacted = true;
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
