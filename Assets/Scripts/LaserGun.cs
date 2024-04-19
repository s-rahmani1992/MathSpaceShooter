using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour {
    private LineRenderer LRender;
    private GameObject target;
    private Vector2 dist;
    private bool shootmode;
    
    public float yPos;
    private RaycastHit2D hit;
    // Use this for initialization
    private float t;
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Cursor");
        LRender = GetComponent<LineRenderer>();
        LRender.enabled = false;
        //t = fireRate = 0.1f;
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        dist = target.transform.position - transform.position;
        transform.localEulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, dist));
        if (Input.GetMouseButtonDown(0) && Time.timeScale > 0)
        {
            LRender.enabled = true;
            InvokeRepeating("shoot", 0, 0.05f);
            GetComponent<AudioSource>().Play();
        }
        
        if (Input.GetMouseButton(0) && Time.timeScale > 0)
        {
            LRender.materials[0].mainTextureOffset -= 3*Time.deltaTime * Vector2.right;
        }
            
        if (Input.GetMouseButtonUp(0) && Time.timeScale > 0)
        {
            GetComponent<AudioSource>().Stop();
            LRender.materials[0].mainTextureOffset = Vector2.zero;
            CancelInvoke("shoot");
            LRender.enabled = false;
        }
            
    }

    void shoot()
    {
        
        if ((hit = Physics2D.Raycast(transform.position, dist, 20, 1 << 4)))
        {
            //print("hit");
            GameDatas data = GameObject.Find("GameData").GetComponent<GameDatas>();
            if ( hit.collider.tag == "asteroid")
            {
                LRender.SetPositions(new Vector3[] { transform.TransformPoint(new Vector3(0, yPos, 0)), hit.point });
                hit.transform.GetChild(3).localScale -= (7.5f * hit.transform.GetComponent<AsteroidBehaviour>().life) * Vector3.right;
                if (hit.transform.GetChild(3).localScale.x < 0)
                {
                    LevelManager level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                    
                    GameObject.Instantiate(level.asterExplosion, hit.transform.position, Quaternion.identity);
                    if (hit.transform.GetComponent<AsteroidBehaviour>().currentNum == level.goalNum)
                    {
                        GameObject.Instantiate(level.tick, new Vector3(0, 2, 0), Quaternion.identity);
                        data.rights++;
                        GameObject.Instantiate(level.coin, hit.transform.position, Quaternion.identity);
                        level.GenerateMultiplier();
                    }
                    else
                    {
                        GameObject.Instantiate(level.cross, new Vector3(0, 2, 0), Quaternion.identity);
                        data.wrongs++;
                        data.coinCount -= 1;
                        level.coins.text = data.coinCount.ToString();
                    }
                    Destroy(hit.transform.gameObject);
                }
            }
            else if(hit.collider.tag == "enemy")
            {
                LRender.SetPositions(new Vector3[] { transform.TransformPoint(new Vector3(0, yPos, 0)), hit.point });
                hit.transform.GetChild(0).localScale -= (7.5f * hit.transform.GetComponent<Enemy1Behaviour>().life) * Vector3.right;
                if (hit.transform.GetChild(0).localScale.x < 0)
                {
                    LevelManager level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                    
                    GameObject.Instantiate(level.enemyExplosion, hit.transform.position, Quaternion.identity);
                    data.coinCount++;
                    data.enemies++;
                    level.coins.text = data.coinCount.ToString();
                    Destroy(hit.transform.gameObject);
                    level.EnemyExists = false;
                }
            }
                
        }
        else
            LRender.SetPositions(new Vector3[] { transform.TransformPoint(new Vector3(0,yPos,0)), transform.position + 12 * (Vector3)dist.normalized });
    }
}
