using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlacement : MonoBehaviour {
    //public int placement;
    public int weaponNum;
    public GameObject up;
	// Use this for initialization
	void Start () {
        GameDatas g = GameObject.Find("GameData").GetComponent<GameDatas>();
        weaponNum = g.currentGuns[transform.GetSiblingIndex()];

        //up = GameObject.Find("Ups");
        
        GetComponent<SpriteRenderer>().sprite = up.transform.GetChild(weaponNum).GetComponent<gunup>().prev;
    }
	
	// Update is called once per frame
	void Update () {
        //print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

    private void OnMouseDown()
    {
        UpgradeManager x = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();
        if(x.currentIndex == 3 || x.currentIndex == 4)
        {
            GameObject.Find("MissileUps").SetActive(false);
            up.SetActive(true);
        }

        transform.parent.GetChild(x.currentIndex + 5).GetComponent<SpriteRenderer>().color =new Color(1.0f, 0.0f, 1.0f);
        transform.parent.GetChild(transform.GetSiblingIndex() + 5).GetComponent<SpriteRenderer>().color = Color.red;

        GameDatas g = GameObject.Find("GameData").GetComponent<GameDatas>();
        x.currentIndex = transform.GetSiblingIndex();

        
        for(int i = 0; i < g.gunBuyIndexes[x.currentIndex]; i++)
        {
            if (i != weaponNum)
            {
                up.transform.GetChild(i).gameObject.SetActive(true);
                up.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = x.select;
            }
            else
                up.transform.GetChild(i).gameObject.SetActive(false);
            up.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
        }

        for(int i = g.gunBuyIndexes[x.currentIndex]; i < 5; i++)
        {
            up.transform.GetChild(i).gameObject.SetActive(true);
            up.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = up.transform.GetChild(i).GetComponent<gunup>().buy;
            up.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.gray;
        }
        up.transform.GetChild(g.gunBuyIndexes[x.currentIndex]).GetComponent<SpriteRenderer>().color = Color.white;
    }
}
