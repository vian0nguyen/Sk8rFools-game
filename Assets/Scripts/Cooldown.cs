using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{

    public bool interact = true;
    // Start is called before the first frame update
    void Start()
    {
        interact = true;
    }

 public void cooldown()
    {
        StartCoroutine("wait");
    }

    public IEnumerator wait()
    {
        interact = false;
        yield return new WaitForSeconds(0.5f);
        interact = true;
    }
}
