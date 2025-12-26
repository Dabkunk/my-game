using UnityEngine;

public class PiepMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    private AudioSource audioSource;
    public AudioClip ScorePointClip;
    private bool hasTriggered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && hasTriggered == false)
        {
            logic.addScore(1);
            logic.addHP(1);
            audioSource.clip = ScorePointClip;
            audioSource.Play();
            hasTriggered = true;

        }
        
        
    }
}
