using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour {
    float jump;
	// Use this for initialization
	void Start () {
        jump = 2 * transform.lossyScale.x * GetComponent<SpriteRenderer>().sprite.bounds.size.y;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(0, Time.deltaTime, 0);
        if (transform.position.y <= -11.41f)
            transform.position += new Vector3(0, jump, 0);
	}
}
