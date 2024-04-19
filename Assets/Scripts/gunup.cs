using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunup : MonoBehaviour {
    public int upNum, price;
    public string ID;
    public Sprite prev, buy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        
        transform.localScale = new Vector3(0.25f, 0.25f, transform.localScale.z);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, transform.localScale.z);
        UpgradeManager x = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
        GameDatas dat = GameObject.Find("GameData").GetComponent<GameDatas>();

        if(upNum < dat.gunBuyIndexes[x.currentIndex]) // selecting bought item
        {
            dat.currentGuns[x.currentIndex] = upNum;
            Transform up = GameObject.Find("spaceship").transform;
            up.GetChild(x.currentIndex).GetComponent<SpriteRenderer>().sprite = prev;
            // set prevoious selected item active
            transform.parent.GetChild(up.GetChild(x.currentIndex).GetComponent<GunPlacement>().weaponNum).gameObject.SetActive(true);


            up.GetChild(x.currentIndex).GetComponent<GunPlacement>().weaponNum = upNum;
            gameObject.SetActive(false);
        }

        else if(upNum == dat.gunBuyIndexes[x.currentIndex]) // buying the item
        {
            if(dat.coinCount >= price)
            {
                GetComponent<SpriteRenderer>().sprite = x.select;
                dat.gunBuyIndexes[x.currentIndex]++;
                transform.parent.GetChild(dat.gunBuyIndexes[x.currentIndex]).GetComponent<SpriteRenderer>().color = Color.white;
                dat.coinCount -= price;
                GameObject.Find("coins").GetComponent<Text>().text = dat.coinCount.ToString();
                
            }

            else
            {

            }
        }

        
    }
}
