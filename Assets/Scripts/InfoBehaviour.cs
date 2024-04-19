using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBehaviour : MonoBehaviour
{
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject info;
        if ((info = GameObject.FindWithTag("info")) != null)
            info.SetActive(false);
        transform.parent.GetChild(index + 4).gameObject.SetActive(true);
    }
}
