using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Script : MonoBehaviour
{
   
    public void Play_Again()
    {
        SceneManager.LoadScene("Flapping_Brid");
    }
    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
