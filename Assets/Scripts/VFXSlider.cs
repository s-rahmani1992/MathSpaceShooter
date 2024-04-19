using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VFXSlider : MonoBehaviour, IPointerUpHandler {
    private GameDatas data;
    public AudioClip clip;
    //private AudioSource audio;
	// Use this for initialization
	void Start () {
        data = GameObject.Find("GameData").GetComponent<GameDatas>();
        //GetComponent<Slider>().value = data.VFXVolume;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        GetComponent<Slider>().value = data.VFXVolume;
    }

    public void VFXChange()
    {
        data.VFXVolume = GetComponent<Slider>().value;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AudioSource.PlayClipAtPoint(clip, new Vector3(0,0,-9), data.VFXVolume);
        //throw new System.NotImplementedException();
    }
}
