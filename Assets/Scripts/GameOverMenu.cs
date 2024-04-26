using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text scoreText;
    [SerializeField] TMPro.TMP_Text gameOverText;

    public void Show(int score, bool isBest)
    {
        gameOverText.text = (isBest ? "You Lost! New High Score:" : "You Lost! Your Score:");
        scoreText.text = score.ToString(); 
        gameObject.SetActive(true);
    }

    public void OnMenuClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Upgrade");
    }

    public void OnRestartClicked()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("PlayField");
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayField");
    }
}
