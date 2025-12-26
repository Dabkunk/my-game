using UnityEngine;

public class PiepSpawner : MonoBehaviour
{
    [Header("The peips")]
    public GameObject piep;
    

    [Header("The pillras")]
    public GameObject pillras;

    [Header("The oice pieps")]
    public GameObject[] oice_pieps;

    public float spawnRate = 2;
    private float timer = 0;
    public float heightoffset = 10;

    //logic from logic manager
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
            spawnPiep();
            timer = 0;
        }

            
    }

    void spawnPiep()
    {
       

        float lowestPoint = transform.position.y - heightoffset;
        float highestPoint = transform.position.y + heightoffset;
        if (logic.playerScore < 20)
        {
            Instantiate(piep, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        } 
        if (logic.playerScore > 20 && logic.playerScore < 50)
        {
            Instantiate(pillras, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
        if (logic.playerScore >= 50)
        {

                int RandomIndex = Random.Range(0,2);
                Instantiate(oice_pieps[RandomIndex], new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
    }

}
