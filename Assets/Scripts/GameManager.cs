using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool overworldCam = true;

    public float wait;
    public GameObject fade;

    public int arc = 0;

    public DialogueManager dm;
    public NPCManager npcManager;

    // Start is called before the first frame update
    void Start()
    {
        fade.GetComponent<SpriteRenderer>();
    }

    public void SwitchPriority()
    {
       //overworldCam = !overworldCam;
    }
    public void Transition()
    {
        fade.SetActive(true);
        StartCoroutine("SceneTransition");
    }
    // Update is called once per frame
     IEnumerator SceneTransition()
    {
        SwitchPriority();
        yield return new WaitForSeconds(wait);
        fade.SetActive(false);
    }

    //advances the storyline.  if you don't want to accidentally skip dialogue for this arc, add this tag into the very last dialgoue for this arc that you want the player to see
    public void AdvanceArcs()
    {
        arc++;
    }
}
