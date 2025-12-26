using UnityEngine;

public class Treespawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public float spawnRate = 0;
    private float timer = 0;
    public float heightoffset = 0;
    public LogicScript logic;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
            
        }
        else
        {
            spawnTree();
            timer = 0;
        }
    }
    void spawnTree()

    {   if (logic.playerScore < 20)
        {
            int RandomIndex = Random.Range(0, 3);
            float lowestPoint = transform.position.y - heightoffset;
            float highestPoint = transform.position.y + heightoffset;
            Instantiate(myObjects[RandomIndex], new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
        if (logic.playerScore > 20 && logic.playerScore < 50) 
        {

            int RandomIndex = Random.Range(3, 6);
            float lowestPoint = transform.position.y - heightoffset;
            float highestPoint = transform.position.y + heightoffset;
            Instantiate(myObjects[RandomIndex], new Vector3(transform.position.x, -40, 0), transform.rotation);
        }
        if (logic.playerScore > 50)
        {
            int RandomIndex = Random.Range(6, 9);
            float lowestPoint = transform.position.y - heightoffset;
            float highestPoint = transform.position.y + heightoffset;
            Instantiate(myObjects[RandomIndex], new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }



    }
}
