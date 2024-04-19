using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempObjects : MonoBehaviour {
    public float time;
    float t;
	// Use this for initialization
	void Start () {
        t = 0;
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t > time)
            GameObject.Destroy(gameObject);
	}
}
