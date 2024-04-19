using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualGunBehaviour : MonoBehaviour {
    private GameObject target;
    private Vector2 dist;
    
    public GameObject bullet;
    public float fireRate;
    public float xPos, yPos;
    // Use this for initialization
    private float t;
	void Start () {
        target = GameObject.Find("Cursor");
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;

        dist = target.transform.position - transform.position;
        transform.localEulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, dist));
        if (Input.GetMouseButtonDown(0) && Time.timeScale > 0)  
            GetComponent<AudioSource>().Play();
        if (Input.GetMouseButton(0) && t >= fireRate && t < fireRate + Time.deltaTime && Time.timeScale > 0)
        {
            GameObject.Instantiate(bullet, transform.TransformPoint( new Vector3(xPos, yPos, 0)), transform.rotation).GetComponent<BulletBehaviour>().speed = 8 * transform.TransformDirection(Vector3.up);
            
        }
            
        else if(Input.GetMouseButton(0) && t >= fireRate && t >= 2 * fireRate && Time.timeScale > 0)
        {
            t = 0;
            GameObject.Instantiate(bullet, transform.TransformPoint(new Vector3(-xPos, yPos, 0)), transform.rotation).GetComponent<BulletBehaviour>().speed = 8 * transform.TransformDirection(Vector3.up);
        }

        if(Input.GetMouseButtonUp(0))
            GetComponent<AudioSource>().Stop();

    }
}
