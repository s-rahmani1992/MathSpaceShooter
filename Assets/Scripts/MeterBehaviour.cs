using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterBehaviour : MonoBehaviour {
    GameDatas data;
    public int currentScore;
    int count;
    float t;
    Text meter;
	// Use this for initialization
	void Start () {
        meter = GetComponent<Text>();
        data =GameObject.Find("GameData").GetComponent<GameDatas>();
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        currentScore = (int)(20 * Time.timeSinceLevelLoad);
        meter.text = currentScore.ToString();
        if (currentScore > (count + 1) * 1000)
        {
            if(data.difficulty != 4)
                data.difficulty++;
            count++;
        }
            
	}
}
