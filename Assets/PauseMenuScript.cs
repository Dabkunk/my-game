using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public static bool GamePaused = false;

    public GameObject PauseMenuUi;

    public LogicScript logic;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
                

        }
        if (logic.playerScore == 100)
        {
            SceneManager.LoadScene("End.");
        }
 
    }
    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void LoadOptions()
    {
        Debug.Log("Loading Options...");
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quitting Game...");
        SceneManager.LoadScene("Menu");

    }
    
}
