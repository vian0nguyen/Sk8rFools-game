using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionSave : MonoBehaviour
{
    public GameObject player;
    //save player position tutorial https://www.youtube.com/watch?v=xnbvK4iRCfI
    public float pX;
    public float pY;
    public float pZ;
    // Use this for initialization
    void Start()
    {
        player = this.gameObject;
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {

            float pX = player.transform.position.x;
            float pY = player.transform.position.y;
       
            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");

            transform.position = new Vector3(pX, pY);

            // Reset, so that the save will be used only once
            PlayerPrefs.SetInt("Saved", 0);
            PlayerPrefs.Save();
        }
    }
    
    public void PositionSave() //this function is being used in 
    {
        PlayerPrefs.SetFloat("p_x", transform.position.x);
        PlayerPrefs.SetFloat("p_y", transform.position.y);

        player.transform.position = new Vector3(pX, pY, pZ);

        PlayerPrefs.SetInt("Saved", 1);
        // You need to actually save the values!
        PlayerPrefs.Save();
    }

    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }

}
