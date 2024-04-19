using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleUpscroller : MonoBehaviour {
    float speed;
    RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    speed = -0.2f;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    speed = 0.2f;
        //}

        if (Input.touchCount > 0)
        {
            
            if (!Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector3.forward, out hit))
            {
                GameObject info;
                if ((info = GameObject.FindWithTag("info")) != null)
                    info.SetActive(false);
            }
            else if (hit.collider.name == "UpsController")
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
                    speed = Time.deltaTime * Input.GetTouch(0).deltaPosition.x;
            }
        } 
        else
            speed = Mathf.Lerp(speed, 0, 0.01f);
        transform.position += speed * Vector3.right;
        if (transform.position.x > 1)
            transform.position = new Vector3(1, transform.position.y, transform.position.z);
        if (transform.position.x < -5.5f)
            transform.position = new Vector3(-5.5f, transform.position.y, transform.position.z);
    }
}
