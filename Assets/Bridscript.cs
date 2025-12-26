using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Bridscript : MonoBehaviour
{
    //Bird hitbox
    public Rigidbody2D myRigidBody;

    //bird flap strength & movement
    public float flapStrength;
    public float flapMovement;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    //logic from logic manager
    public LogicScript logic;

    //set bird to alive
    public bool birdIsAlive = true;

    //bird animations
    public GameObject birdwingup_0;
    public GameObject birdwingdown_0;

    //bird sound effects
    public AudioClip BirdflapSoundClip;
    private AudioSource audioSource;
    public AudioClip BirdhitSoundClip;

    //bird deadzones
    public float DeadzoneX = -85f;
    public float DeadzoneY_Down = -70f;
    public float DeadzoneY_Up = 70f;
    public float tolerance = 0.2f;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdwingup_0.SetActive(true);
        birdwingdown_0.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {   //Bird flap
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true || Input.GetMouseButtonDown(0) && birdIsAlive == true)
        { 
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            birdwingup_0.SetActive(false);
            birdwingdown_0.SetActive(true);
            //Bird sound flap
            audioSource.clip = BirdflapSoundClip;
            audioSource.Play();

        }
        //touch setup
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
        }

            //reset bird animation
        if (Input.GetKeyUp(KeyCode.Space) == true && birdIsAlive == true||Input.GetMouseButtonUp(0) && birdIsAlive == true)
        {
           birdwingup_0.SetActive(true);
            birdwingdown_0.SetActive(false);
        }
        //Bird move left
        if (Input.GetKeyDown(KeyCode.A) == true && birdIsAlive == true || Input.GetKeyDown(KeyCode.LeftArrow) && birdIsAlive == true)
        {
            myRigidBody.linearVelocity = Vector2.left * flapMovement;
        }
        //Bird move right
        if (Input.GetKeyDown(KeyCode.D) == true && birdIsAlive == true || Input.GetKeyDown(KeyCode.RightArrow) && birdIsAlive == true)
        {
            myRigidBody.linearVelocity = Vector2.right * flapMovement;
        }
        // Touch swipe detection
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && birdIsAlive == true)
        {
            float swipeDistance = endTouchPosition.x - startTouchPosition.x;
            float minSwipeDistance = 25f; // Minimum distance to count as swipe

            if (Mathf.Abs(swipeDistance) > minSwipeDistance) // Only if it's a significant swipe
            {
                if (swipeDistance > 0) // Swipe right
                {
                    myRigidBody.linearVelocity = Vector2.right * flapMovement;
                }
                else // Swipe left
                {
                    myRigidBody.linearVelocity = Vector2.left * flapMovement;
                }
            }
        }



        //Bird falls
        if (Mathf.Abs(transform.position.x - DeadzoneX) <= tolerance && logic.playerScore >= 20)
        {
            logic.minusLives(1);
            transform.position = new Vector2(0f, 0f);
            //bird hit pipe
            audioSource.clip = BirdhitSoundClip;
            audioSource.Play();
        }
        if (Mathf.Abs(transform.position.y - DeadzoneY_Down) <= tolerance && logic.playerScore >= 20)
        {
            logic.minusLives(1);
            transform.position = new Vector2(0f, 0f);
            //bird hit pipe
            audioSource.clip = BirdhitSoundClip;
            audioSource.Play();
        }
        if (Mathf.Abs(transform.position.y - DeadzoneY_Up) <= tolerance && logic.playerScore >= 20)
        {
            logic.minusLives(1);
            transform.position = new Vector2(0f, 0f);
            //bird hit pipe
            audioSource.clip = BirdhitSoundClip;
            audioSource.Play();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   //Bird Collide
        if (collision.gameObject.layer == 6 && birdIsAlive == true)
        {
            
            logic.minusLives(1);
            transform.position = new Vector2(0f, 0f);
            //bird hit pipe
            audioSource.clip = BirdhitSoundClip;
            audioSource.Play();
        }
        if (logic.Lives == 0)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
        

    }

}
