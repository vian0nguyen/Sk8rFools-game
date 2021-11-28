using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SortOrder : MonoBehaviour
{
    public Renderer render;
    public int scale;
    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        render.sortingOrder = (int)(transform.position.y * - scale); //number depends on the scale of the game!
    }
}
