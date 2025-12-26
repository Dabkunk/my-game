using UnityEngine;

public class music_changer : MonoBehaviour
{
    public AudioSource currentmusic;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public LogicScript logic;
    private bool musicChanged1 = false;
    private bool musicChanged2 = false;
    private bool musicChanged3 = false;
    void Start()
    {
        currentmusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (logic.playerScore < 20 && musicChanged1 == false)
        {
            currentmusic.clip = music1;
            currentmusic.Play();
            musicChanged1 = true;
        }
        if (logic.playerScore >= 20 && musicChanged2 == false)
        {
            currentmusic.clip = music2;
            currentmusic.Play();
            musicChanged2 = true;
        }
        if (logic.playerScore >= 50 && musicChanged3 == false)
        {
            currentmusic.clip = music3;
            currentmusic.Play();
            musicChanged3 = true;
        }

    }
   
}
