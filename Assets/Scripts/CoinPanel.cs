﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = GameObject.Find("GameData").GetComponent<GameDatas>().coinCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
