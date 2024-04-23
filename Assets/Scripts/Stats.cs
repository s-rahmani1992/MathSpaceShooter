using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stats : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameDatas data = GameObject.Find("GameData").GetComponent<GameDatas>();
        Transform content = transform.GetChild(4).GetComponent<ScrollRect>().content;
        data.seconds += (int)(System.DateTime.Now - data.start).TotalSeconds;

        content.GetChild(0).GetComponent<Text>().text = data.bestscore.ToString();
        content.GetChild(1).GetComponent<Text>().text = (new System.TimeSpan((long)data.seconds * 10000000)).ToString();
        content.GetChild(2).GetComponent<Text>().text = data.rights.ToString();
        content.GetChild(3).GetComponent<Text>().text = data.wrongs.ToString();
        content.GetChild(4).GetComponent<Text>().text = data.enemies.ToString();
        content.GetChild(5).GetComponent<Text>().text = data.loses.ToString();

        content.GetChild(6).GetComponent<Text>().text = "High Score";
        content.GetChild(7).GetComponent<Text>().text = "Total Play Duration";
        content.GetChild(8).GetComponent<Text>().text = "Correct Asteroids";
        content.GetChild(9).GetComponent<Text>().text = "Wrong Asteroids";
        content.GetChild(10).GetComponent<Text>().text = "enemies destroyed";
        content.GetChild(11).GetComponent<Text>().text = "Loses";
        
        data.start = System.DateTime.Now;
        print(Camera.main.WorldToViewportPoint( transform.GetChild(4).position));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
