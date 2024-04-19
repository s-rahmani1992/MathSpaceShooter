using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour 
{
    [SerializeField] UserSettings userSettings;
    // Use this for initialization
    
    private float[] coords = { 0.0f, 0.2f, -0.76f, 0.09f, 0.76f, 0.09f };
    public int health;
	void Start () {
        transform.parent.GetComponent<Animator>().SetBool("hit", false);
        health = 100;
        GameDatas gData = GameObject.Find("GameData").GetComponent<GameDatas>();
        //GameObject.Instantiate(Resources.Load("Lasergun") as GameObject, transform.position, Quaternion.identity);
        for (int i = 0; i < 3; i++)   
        {
            if (gData.gunIDs[ gData.currentGuns[i]] != "")
                GameObject.Instantiate(Resources.Load(gData.gunIDs[gData.currentGuns[i]]) as GameObject, transform.position + new Vector3(coords[2 * i],
                    coords[2 * i + 1]), Quaternion.identity, transform).GetComponent<AudioSource>().volume = userSettings.SfxVolume;       
        }
        if (gData.missileIDs[gData.currentMissiles[0]] != "")
            GameObject.Instantiate(Resources.Load(gData.missileIDs[gData.currentMissiles[0]]) as GameObject, transform.position + new Vector3(-0.3625f, 0.045f), 
                Quaternion.identity, transform);
        if (gData.missileIDs[gData.currentMissiles[1]] != "")
            GameObject.Instantiate(Resources.Load(gData.missileIDs[gData.currentMissiles[1]]) as GameObject, transform.position + new Vector3(0.3625f, 0.045f),
                Quaternion.identity, transform).GetComponent<SpriteRenderer>().flipX = true;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localPosition += 3 * Time.deltaTime * Vector3.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localPosition += 3 * Time.deltaTime * Vector3.right;
        }
        transform.position += 9 * Time.deltaTime * new Vector3( Input.acceleration.x,0,0);
        if (transform.localPosition.x < -3.9f)
            transform.localPosition = new Vector3(-3.9f, transform.localPosition.y, 0);
        if (transform.localPosition.x > 3.9f)
            transform.localPosition = new Vector3(3.9f, transform.localPosition.y, 0);
    }
}
