using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseUI.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void Resume()
    {
        isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
