using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TapsellSDK;

public class GameDatas : MonoBehaviour 
{
    public int seconds, rights, wrongs, loses, bestscore, difficulty, enemies;
    public DateTime start;
    private static GameDatas x;
    public int meterRecord, coinCount;
    //public int[] PlayerGuns = new int[3];
    public string[] gunIDs, missileIDs;
    public int[] gunBuyIndexes, currentGuns, missileBuyIndexes, currentMissiles;
    
    private void Awake() {
        if (x == null) {
            x = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
            DestroyImmediate(gameObject);      
    }
    // Use this for initialization
    void Start () {
        start = DateTime.Now;
        UnityEngine.SceneManagement.SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        //difficulty = PlayerPrefs.GetInt("Difficulty");
        seconds = PlayerPrefs.GetInt("timePlayed");
        bestscore = PlayerPrefs.GetInt("BestScore");
        enemies = PlayerPrefs.GetInt("Enemies");
        currentGuns[0] = PlayerPrefs.GetInt("Weapon0") + 1;
        currentGuns[1] = PlayerPrefs.GetInt("Weapon1");
        currentGuns[2] = PlayerPrefs.GetInt("Weapon2");
        coinCount = PlayerPrefs.GetInt("Coins");
        gunBuyIndexes[0] = PlayerPrefs.GetInt("BuyIndex1") + 2;
        gunBuyIndexes[1] = PlayerPrefs.GetInt("BuyIndex2") + 1;
        gunBuyIndexes[2] = PlayerPrefs.GetInt("BuyIndex3") + 1;
        currentMissiles[0] = PlayerPrefs.GetInt("Missile1");
        currentMissiles[1] = PlayerPrefs.GetInt("Missile2");
        missileBuyIndexes[0] = PlayerPrefs.GetInt("buyMissile1") + 1;
        missileBuyIndexes[1] = PlayerPrefs.GetInt("buyMissile2") + 1;
        rights = PlayerPrefs.GetInt("Rights");
        wrongs = PlayerPrefs.GetInt("Wrongs");
        loses = PlayerPrefs.GetInt("Loses");
        PlayerPrefs.DeleteKey("Difficulty");


        Tapsell.Initialize("pqncrqrtlrpahorrkfrtebtaeoifbspelocefdacbqdqtnojljtpnnsndrjiseasdcscno");
        //PlayerPrefs.DeleteAll();
    }

    private void SceneManager_activeSceneChanged(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.Scene arg1)
    {
        if (arg1.name == "PlayField")
            GetComponent<AudioSource>().enabled = false;
        else if (arg1.name == "Upgrade")
            GetComponent<AudioSource>().enabled = true;
        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnApplicationQuit()
    {
        //PlayerPrefs.SetInt("Difficulty", difficulty);
        PlayerPrefs.SetInt("Weapon0", currentGuns[0] - 1);
        PlayerPrefs.SetInt("Weapon1", currentGuns[1]);
        PlayerPrefs.SetInt("Weapon2", currentGuns[2]);
        PlayerPrefs.SetInt("BuyIndex1", gunBuyIndexes[0] - 2);
        PlayerPrefs.SetInt("BuyIndex2", gunBuyIndexes[1] - 1);
        PlayerPrefs.SetInt("BuyIndex3", gunBuyIndexes[2] - 1);
        PlayerPrefs.SetInt("Enemies", enemies);
        PlayerPrefs.SetInt("Coins", coinCount);
        PlayerPrefs.SetInt("BestScore", bestscore);
        PlayerPrefs.SetInt("Missile1", currentMissiles[0]);
        PlayerPrefs.SetInt("Missile2", currentMissiles[1]);
        PlayerPrefs.SetInt("buyMissile1", missileBuyIndexes[0] - 1);
        PlayerPrefs.SetInt("buyMissile2", missileBuyIndexes[1] - 1);
        PlayerPrefs.SetInt("Rights", rights);
        PlayerPrefs.SetInt("Wrongs", wrongs);
        PlayerPrefs.SetInt("Loses", loses);
        PlayerPrefs.SetInt("timePlayed", (int)(DateTime.Now - start).TotalSeconds + seconds);
    }
}
