using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {
    public Sprite select;
    public int currentIndex;
    //public Color selectColor;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        GameObject.Find("MissileUps").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
