using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += 4*Time.deltaTime * Vector3.down;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player")
        {
            other.GetComponent<PlayerBehaviour>().health -= 3;
            GameObject.Find("Health").GetComponent<RectTransform>().sizeDelta -= new Vector2(4.5f, 0);
            if (other.GetComponent<PlayerBehaviour>().health <= 0)
            {
                LevelManager level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                GameObject.Instantiate(level.playerExplosion, other.transform.position, Quaternion.identity);
                GameObject.Destroy(other.gameObject);
                level.StartCoroutine(level.DestroyPlayer());
            }
            Destroy(gameObject);
        }

        
    }
}
