using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject player;
    //public SpriteRenderer Select;
    public bool interacted;

    public string LoadScene;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Select = GameObject.FindGameObjectWithTag("Select").GetComponent<SpriteRenderer>();
        //Select = gameObject.GetComponent<SpriteRenderer>();
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
