using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour 
{
    [SerializeField] UserSettings userSettings;
    public GameObject missile;
    private float time;
    public float rate, xPos;
    AudioSource sound;

    RaycastHit hit;
	// Use this for initialization
	void Start () {
        time = rate;
        sound = GetComponent<AudioSource>();
        sound.volume = userSettings.SfxVolume;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        //Android Input

        if (Input.touchCount > 0)
        {
            foreach (var a in Input.touches)
            {
                if (time > rate && Time.timeScale > 0 && Physics.Raycast(Camera.main.ScreenToWorldPoint(a.position), new Vector3(0, 0, 1), out hit)
                    && hit.collider.tag == "panel")
                {
                    if (a.phase == TouchPhase.Began || a.phase == TouchPhase.Stationary || a.phase == TouchPhase.Moved)
                    {
                        //hit.transform.GetComponent<SpriteRenderer>().color = Color.blue;
                        GameObject.Instantiate(missile, transform.position + xPos * Vector3.right, Quaternion.identity);
                        sound.Play();
                        xPos = -xPos;
                        time = 0;
                    }
                    //if(a.phase == TouchPhase.Ended)
                    //    hit.transform.GetComponent<SpriteRenderer>().color = Color.white;
                }
                
            }
        }

        //PC Input

        if (Input.GetMouseButton(2) && time > rate && Time.timeScale > 0)
        {
            GameObject.Instantiate(missile, transform.position + xPos * Vector3.right, Quaternion.identity);
            xPos = -xPos;
            time = 0;
        }
    }
}
