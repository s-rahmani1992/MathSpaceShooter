using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpScroll : MonoBehaviour {
    private RaycastHit hit;
    float speed;
	// Use this for initialization
	void Start () {

        int buy = GameObject.Find("GameData").GetComponent<GameDatas>().gunBuyIndexes[0];
        for(int i = 2; i < buy; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>().select;
        }
        for(int i = buy; i < 5; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = transform.GetChild(i).GetComponent<gunup>().buy;
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.gray;
        }
        transform.GetChild(buy).GetComponent<SpriteRenderer>().color = Color.white;
        buy = GameObject.Find("GameData").GetComponent<GameDatas>().currentGuns[0];
        transform.GetChild(buy).gameObject.SetActive(false);
       
	}
	
	// Update is called once per frame
	void Update () {
        //PC Input

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = -0.2f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            speed = 0.2f;
        }

        //Android Input

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
            speed = Mathf.Lerp(speed, 0, 0.05f);
        transform.position += speed * Vector3.right;
        if (transform.position.x > 1)
            transform.position = new Vector3(1, transform.position.y, transform.position.z);
        if (transform.position.x < -5.5f)
            transform.position = new Vector3(-5.5f, transform.position.y, transform.position.z);
    }
}
