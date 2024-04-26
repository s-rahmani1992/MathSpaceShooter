using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void OnMenuClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Upgrade");
    }

    public void OnResumeClicked()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
