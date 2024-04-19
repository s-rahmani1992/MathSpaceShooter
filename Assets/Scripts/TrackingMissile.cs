using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMissile : MonoBehaviour {
    GameObject target;
    Rigidbody2D rigid;
    Vector2 dist;
    public float damage;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("enemy");
        if (target)
        {
            InvokeRepeating("Track", 0.1f, 0.05f);
        }
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, 6);
        //InvokeRepeating("Track", 0.1f, 1);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Track()
    {
        //target = GameObject.FindGameObjectWithTag("enemy");
        if(target != null)
        {
            dist = (Vector2)(target.transform.position - transform.position);
            if (Vector2.SignedAngle(dist, rigid.velocity) < 0)
            {

                rigid.rotation += 3;

            }

            else
            {
                rigid.rotation -= 3;
            }
            rigid.velocity = transform.TransformVector(20 * Vector3.up);
        }
        
    }
}
