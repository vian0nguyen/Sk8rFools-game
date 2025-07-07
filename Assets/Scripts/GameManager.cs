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
}
