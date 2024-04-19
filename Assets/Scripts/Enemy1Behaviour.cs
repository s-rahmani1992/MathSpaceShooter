using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour {
    public GameObject bullet;
    private Vector2 speed;
    public float life;
	// Use this for initialization
	void Start () {
        speed = new Vector2(1, -1);
        GameDatas data = GameObject.Find("GameData").GetComponent<GameDatas>();
        life = 1f / (600 * data.difficulty + 200);
        InvokeRepeating("Shoot", 1, 7);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 1.8f)
            speed = new Vector2(speed.x, 0);
        transform.position += Time.deltaTime * (Vector3)speed;
        if (transform.position.x < -1.8f)
            speed = new Vector2(1, speed.y);
        if (transform.position.x > 1.8f)
            speed = new Vector2(-1, speed.y);
    }

    void Shoot()
    {
        StartCoroutine("EnemyShoot");
    }

    IEnumerator EnemyShoot()
    {
        GameObject.Instantiate(bullet, transform.position + new Vector3(0.35f, -1f,0), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        GameObject.Instantiate(bullet, transform.position + new Vector3(-0.35f, -1f, 0), Quaternion.identity);
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            transform.GetChild(0).localScale -= (other.GetComponent<BulletBehaviour>().damage *life) * Vector3.right;
            Destroy(other.gameObject);
            if (transform.GetChild(0).localScale.x < 0)
            {
                LevelManager level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                GameDatas data = GameObject.Find("GameData").GetComponent<GameDatas>();
                GameObject.Instantiate(level.enemyExplosion, transform.position, Quaternion.identity);
                data.coinCount++;
                data.enemies++;
                level.coins.text = data.coinCount.ToString();
                level.EnemyExists = false;
                Destroy(gameObject);
            }
            
        }

        else if(other.tag == "missile")
        {
            transform.GetChild(0).localScale -= (other.GetComponent<TrackingMissile>().damage * life) * Vector3.right;
            LevelManager level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            GameObject.Instantiate(level.missileExplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            if (transform.GetChild(0).localScale.x < 0)
            {
                GameObject.Instantiate(level.enemyExplosion, transform.position, Quaternion.identity);
                GameDatas data = GameObject.Find("GameData").GetComponent<GameDatas>();
                data.coinCount++;
                data.enemies++;
                level.coins.text = data.coinCount.ToString();
                level.EnemyExists = false;
                Destroy(gameObject);
            }
        }
    }
}
