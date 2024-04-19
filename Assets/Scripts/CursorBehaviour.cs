using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour {
    RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Android Input

        if (Input.touchCount > 0 && Input.touchCount < 3)
        {
            foreach (var a in Input.touches)
            {
                if ((Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary) &&
                    Physics.Raycast(Camera.main.ScreenToWorldPoint(a.position), new Vector3(0, 0, 1), out hit))
                {
                    if (hit.collider.tag == "cursorpanel")
                    {
                        transform.position = Camera.main.ScreenToWorldPoint(a.position);
                        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    }
                }
            }
        }

        //PC Input

        //if (Input.GetMouseButton(0))
        //{
        //    transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //    if (transform.position.x > 2.8f)
        //        transform.position = new Vector3(2.8f, transform.position.y, 0);
        //    else if (transform.position.x < -2.8f)
        //        transform.position = new Vector3(-2.8f, transform.position.y, 0);
        //    if (transform.position.y > 3.2f)
        //        transform.position = new Vector3(transform.position.x, 3.2f, 0);
        //    else if (transform.position.y < -2.0f)
        //        transform.position = new Vector3(transform.position.x, -2.0f, 0);
        //}
    }
}
