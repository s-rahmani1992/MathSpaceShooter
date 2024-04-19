using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPanelBehaviour : MonoBehaviour
{
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        render.color = Color.blue;
    }

    private void OnMouseUp()
    {
        render.color = Color.white;
    }
}
