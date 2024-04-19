using System;
using System.Collections;
using System.Collections.Generic;
using TapsellSDK;
using UnityEngine;

public class BackControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        transform.localScale = 0.9f * transform.localScale;
        if (gameObject.name == "play")
            UnityEngine.SceneManagement.SceneManager.LoadScene("PlayField");
        else if (gameObject.name == "Menu")
            UnityEngine.SceneManagement.SceneManager.LoadScene("Upgrade");
        else if (gameObject.name == "Retry")
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("PlayField");
            UnityEngine.SceneManagement.SceneManager.LoadScene("PlayField");
        }
        else if(gameObject.name == "Home")
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        else if (gameObject.name == "Resume")
        {
            transform.parent.gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        else if(gameObject.name == "vid")
        {
            Tapsell.RequestAd("5cdab90b33c2a3000160a8ac", true, onAdAvailableAction, null, null,null, null);
        }
        //else if (gameObject.name == "MenuPlay")
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene("Upgrade");
        //}
    }

    private void onAdAvailableAction(TapsellAd obj)
    {
        TapsellShowOptions op = new TapsellShowOptions();
        op.backDisabled = true;
        op.immersiveMode = true;
        op.rotationMode = TapsellShowOptions.ROTATION_UNLOCKED;
        op.showDialog = false;
        Tapsell.ShowAd(obj, op);
        Tapsell.SetRewardListener(onFinishAd);
    }

    private void onFinishAd(TapsellAdFinishedResult obj)
    {
        if (obj.completed)
        {
            GameDatas dat = GameObject.Find("GameData").GetComponent<GameDatas>();
            dat.coinCount += 400;
            GameObject.Find("coins").GetComponent<UnityEngine.UI.Text>().text = dat.coinCount.ToString();
        } 
    }
}
