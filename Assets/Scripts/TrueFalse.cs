using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueFalse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = Vector3.Lerp(transform.localScale, 3 * Vector3.one, 0.4f);
	}
}
