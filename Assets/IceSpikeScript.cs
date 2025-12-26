using UnityEngine;

public class IceSpikeScript : MonoBehaviour
{
    public float Deadzone = -100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < Deadzone)
        {
            Debug.Log("Oice Deleted");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Ice Deleted");
            Destroy(gameObject);
        }
    }



}
