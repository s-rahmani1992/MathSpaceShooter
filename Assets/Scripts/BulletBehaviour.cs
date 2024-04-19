using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    //private float t;
    public Vector2 speed;
    public float damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //t += Time.deltaTime;
        transform.position += Time.deltaTime * (Vector3)speed;
        //if (t >= 5)
        //    GameObject.Destroy(gameObject);
	}
}
