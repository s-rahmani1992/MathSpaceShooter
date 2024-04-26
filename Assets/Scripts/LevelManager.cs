using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour 
{
    [SerializeField] UserSettings userSettings;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameOverMenu gameOverMenu;

    public GameObject missileExplosion, enemyExplosion;
    // Use this for initialization
    public GameObject tick, cross, coin;
    public short leftOp, rightOp, goalNum;
    public int meterCount;
    public Sprite[] asteroidNums, asteroidSprite;
    public Color[] enemyColor, asteroidColor;
    public GameObject aster, asterExplosion, playerExplosion, enemy;
    public Text coins, currentProblem;
    public bool EnemyExists;
    GameDatas data ;

    void Start () {
        data = GameObject.Find("GameData").GetComponent<GameDatas>();
        EnemyExists = false;
        GenerateMultiplier();
        gameOverMenu.gameObject.SetActive(false);
        pauseMenu.SetActive(false);
        coins.text = GameObject.Find("GameData").GetComponent<GameDatas>().coinCount.ToString();
        GetComponent<AudioSource>().volume = userSettings.MusicVolume;
        Time.timeScale = 1;
        InvokeRepeating(nameof(GenerateAsteroid), 2, 3);
        InvokeRepeating(nameof(GenerateEnemy), 8, 8);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameOverMenu.gameObject.activeInHierarchy)
                UnityEngine.SceneManagement.SceneManager.LoadScene("Upgrade");
            else
            {
                if (!pauseMenu.activeSelf)
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1;
                }
            } 
        }   
	}

    public void GenerateMultiplier()
    {
        leftOp = (short)Random.Range(5, 15);
        rightOp = (short)Random.Range(5, 15);
        goalNum = (short)(leftOp * rightOp);
        currentProblem.text = leftOp.ToString() + "  X  " + rightOp.ToString() + " = ?";
    }

    private void GenerateAsteroid()
    {
        GameObject.Instantiate(aster, new Vector3(1.6f * Random.Range(0, 4) - 2.4f, 6, 0),Quaternion.identity).GetComponent<SpriteRenderer>().color = asteroidColor[data.difficulty];
    }

    public IEnumerator DestroyPlayer()
    {
        GameDatas data = GameObject.Find("GameData").GetComponent<GameDatas>();
        MeterBehaviour meter = GameObject.Find("meter").GetComponent<MeterBehaviour>();
        int number = meter.currentScore;
        bool isBest = data.bestscore < number;
        if (isBest)
            data.bestscore = meter.currentScore;
        data.loses++;
        meter.GetComponent<MeterBehaviour>().enabled = false;
        yield return new WaitForSeconds(2);
        gameOverMenu.Show(number, isBest);
        Time.timeScale = 0;
    }

    public IEnumerator Shake(Transform p)
    {
        p.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        p.GetComponent<Animator>().enabled = false;
    }

    public IEnumerator DestroyAsteroid(Vector3 pos)
    {
        GameObject x = GameObject.Instantiate(asterExplosion, pos, Quaternion.identity);
        yield return new WaitForSeconds(1.3f);
        GameObject.Destroy(x);
    }

    void GenerateEnemy()
    {
        if (!EnemyExists)
        {
            GameObject.Instantiate(enemy, new Vector3(Random.Range(-3, 3), 7, 0), Quaternion.identity).GetComponent<SpriteRenderer>().color = enemyColor[data.difficulty];
            EnemyExists = true;
        }
    }
}
