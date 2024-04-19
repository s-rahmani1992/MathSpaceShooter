using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePlacement : MonoBehaviour {

    // Use this for initialization
    public int missileNum;
    public GameObject misUp;
    // Use this for initialization
    void Start()
    {
        GameDatas g = GameObject.Find("GameData").GetComponent<GameDatas>();
        missileNum = g.currentMissiles[transform.GetSiblingIndex()-3];

        //misUp = GameObject.Find("MissileUps");

        GetComponent<SpriteRenderer>().sprite = misUp.transform.GetChild(missileNum).GetComponent<MissileUp>().prev;
    }

    // Update is called once per frame
    void Update()
    {
        //print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void OnMouseDown()
    {
        UpgradeManager x = GameObject.Find("UpgradeManager").GetComponent<UpgradeManager>();

        if(x.currentIndex < 3)
        {
            GameObject.Find("Ups").SetActive(false);
            misUp.SetActive(true);
        }
        transform.parent.GetChild(x.currentIndex + 5).GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 1.0f);
        transform.parent.GetChild(transform.GetSiblingIndex() + 5).GetComponent<SpriteRenderer>().color = Color.red;

        GameDatas g = GameObject.Find("GameData").GetComponent<GameDatas>();
        x.currentIndex = transform.GetSiblingIndex();

        
        for (int i = 0; i < g.missileBuyIndexes[x.currentIndex - 3]; i++)
        {
            if (i != missileNum)
            {
                misUp.transform.GetChild(i).gameObject.SetActive(true);
                misUp.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = x.select;
            }
            else
                misUp.transform.GetChild(i).gameObject.SetActive(false);
            misUp.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
        }

        for (int i = g.missileBuyIndexes[x.currentIndex - 3]; i < 5; i++)
        {
            misUp.transform.GetChild(i).gameObject.SetActive(true);
            misUp.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = misUp.transform.GetChild(i).GetComponent<MissileUp>().buy;
            misUp.transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.gray;
        }
        misUp.transform.GetChild(g.missileBuyIndexes[x.currentIndex - 3]).GetComponent<SpriteRenderer>().color = Color.white;
    }
}
