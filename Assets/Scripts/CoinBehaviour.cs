using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    // Use this for initialization
    Vector3 coinPosition;
	void Start () {
        coinPosition = GameObject.Find("coinpic").GetComponent<RectTransform>().position;
        coinPosition = new Vector3(coinPosition.x, coinPosition.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, coinPosition, 10*Time.deltaTime);
        transform.localScale = Vector3.MoveTowards(transform.localScale, 0.06f * Vector3.one, Time.deltaTime);
        if (transform.position.x < coinPosition.x + 0.05)
        {
            LevelManager level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            GameDatas data = GameObject.Find("GameData").GetComponent<GameDatas>();
            data.coinCount+= 100;
            level.coins.text = data.coinCount.ToString();
            GameObject.Destroy(gameObject);
        }
            
	}
}
