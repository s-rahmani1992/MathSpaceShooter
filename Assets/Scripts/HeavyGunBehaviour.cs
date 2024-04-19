using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGunBehaviour : MonoBehaviour
{

    private GameObject target;
    private Vector2 dist;

    public GameObject bullet;
    public float fireRate;
    public float yPos;
    // Use this for initialization
    private float t;
    void Start()
    {
        target = GameObject.Find("Cursor");
        t = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        dist = target.transform.position - transform.position;
        transform.localEulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, dist));

        if (Input.GetMouseButton(0) && t > fireRate && Time.timeScale > 0)
        {
            GameObject.Instantiate(bullet, transform.TransformPoint(new Vector3(0, yPos, 0)), transform.rotation).GetComponent<BulletBehaviour>().speed = 8 * transform.TransformDirection(Vector3.up);
            GetComponent<AudioSource>().Play();
            t = 0;
        }

    }
}