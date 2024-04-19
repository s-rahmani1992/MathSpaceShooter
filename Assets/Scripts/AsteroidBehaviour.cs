using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidBehaviour : MonoBehaviour {
    public short currentNum, num;
    LevelManager level;
    RectTransform healthBar;
    public GameObject coin;
    GameDatas data;
    public float life;
    int trigs;

    // Use this for initialization
    void Start () {
        data = GameObject.Find("GameData").GetComponent<GameDatas>();
        GameObject manage = GameObject.Find("LevelManager");
        level = manage.GetComponent<LevelManager>();
        healthBar = GameObject.Find("Health").GetComponent<RectTransform>();
        num = level.goalNum;
        life = 1f / (900 * data.difficulty + 300);

        GetComponent<SpriteRenderer>().sprite = level.asteroidSprite[Random.Range(0, 5)];

        //////////Creating random number for the asterois

        float rnd = Random.Range(0.0f, 1.0f);
        if (rnd < 0.3f)
            currentNum = num;
        else if(rnd < 0.65f)
            currentNum = (short)Random.Range(num + 1, num + 10);
        else
            currentNum = (short)Random.Range(num - 10, num - 1);

        //////////Displaying the generated number on the asteroid
        
        short numCopy = currentNum;
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = level.asteroidNums[numCopy % 10];
        numCopy /= 10;
        if(numCopy == 0) {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
        else {
            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = level.asteroidNums[numCopy % 10];
            numCopy /= 10;
            if(numCopy == 0)
            {
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(0).localPosition += new Vector3(0.125f, 0, 0);
                transform.GetChild(1).localPosition += new Vector3(0.125f, 0, 0);
                transform.GetChild(2).localPosition += new Vector3(0.125f, 0, 0);
            }

            else
            {
                transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = level.asteroidNums[numCopy % 10];
                transform.GetChild(0).localPosition += new Vector3(0.25f, 0, 0);
                transform.GetChild(1).localPosition += new Vector3(0.25f, 0, 0);
                transform.GetChild(2).localPosition += new Vector3(0.25f, 0, 0);
            }
               
        }
	}
	
	// Update is called once per frame
	void Update () {
        trigs = 0;
        transform.position += 2 * Time.deltaTime * Vector3.down;  //asteroid has constant velocity
        if(transform.position.y < -8)                             //if it goes out of bound
            GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet" )
        {
            transform.GetChild(3).localScale -= (other.GetComponent<BulletBehaviour>().damage *life) * Vector3.right;
            if(transform.GetChild(3).localScale.x < 0 && (++trigs <= 1))
            {
                if (currentNum == level.goalNum)
                {
                    GameObject.Instantiate(level.tick, new Vector3(0, 2, 0), Quaternion.identity);
                    data.rights++;
                    GameObject.Instantiate(level.coin, transform.position, Quaternion.identity);
                    level.GenerateMultiplier();
                }
                else
                {
                    GameObject.Instantiate(level.cross, new Vector3(0, 2, 0), Quaternion.identity);
                    data.wrongs++;
                    data.coinCount -= 1;
                    level.coins.text = data.coinCount.ToString();
                }

                GameObject.Instantiate(level.asterExplosion, transform.position, Quaternion.identity);
                GameObject.Destroy(gameObject);
            }
            GameObject.Destroy(other.gameObject);
        }

        if(other.tag == "player")
        {
            
            level.StartCoroutine(level.Shake(other.transform.parent));
            other.GetComponent<PlayerBehaviour>().health -= 30;
            healthBar.sizeDelta -= new Vector2(45, 0);
            if(other.GetComponent<PlayerBehaviour>().health <= 0)
            {
                GameObject.Instantiate(level.playerExplosion, other.transform.position, 
                    Quaternion.identity).GetComponent<AudioSource>().volume = data.VFXVolume;
                GameObject.Destroy(other.gameObject);
                level.StartCoroutine(level.DestroyPlayer());
            }

            level.StartCoroutine(level.DestroyAsteroid(transform.position));
            GameObject.Destroy(gameObject);
        }
    }

   
}
