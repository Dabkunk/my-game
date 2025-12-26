using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameoverScreen;
    public int Lives;
    public Text livestext;
    public int HPAdd;
    public AudioClip HPUp;
    private AudioSource audioSource;
    public GameObject PauseMenu;
    //public Text HPAddtext;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameoverScreen.SetActive(true);
    }


    [ContextMenu("Decrease Lives")]
    public void minusLives(int hitToMinus)
    {
        Lives = Lives - hitToMinus;
        livestext.text = Lives.ToString();
    }
    [ContextMenu("Increase Score")]
    public void addHP(int HPToAdd)
    {
        HPAdd = HPAdd + HPToAdd;
        //HPAddtext.text = HPAdd.ToString();
        if (HPAdd == 10 && Lives != 10)
        {
            audioSource.clip = HPUp;
            audioSource.Play();
            minusLives(-1);
            HPAdd = HPAdd - 10;
        }
        else
        {
            minusLives(0);
        }
    }
    public void Update()
    {
        if (playerScore >= 50)
        {
            scoreText.color = Color.black;
        }  
    }
}
