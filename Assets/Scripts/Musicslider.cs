using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musicslider : MonoBehaviour {
    private GameDatas data;
    // Use this for initialization
    void Start () {
        data = GameObject.Find("GameData").GetComponent<GameDatas>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Slider>().value = data.musicVolume;
    }

    public void MusicChange()
    {
        data.musicVolume = GetComponent<Slider>().value;
        data.GetComponent<AudioSource>().volume = data.musicVolume;
    }
}
