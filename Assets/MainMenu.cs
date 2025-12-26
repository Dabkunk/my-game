using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Mainmenu;
    public GameObject OptionsMenu;
  
    public void Start()
    {
        Mainmenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Options()
    {
        Mainmenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void BackToMainMenu()
    {
        Mainmenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }
}
