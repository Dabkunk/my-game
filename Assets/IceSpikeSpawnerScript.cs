using UnityEngine;
using UnityEngine.UIElements;

public class IceSpikeSpawnerScript : MonoBehaviour
{
    public GameObject Icespikes;
    public LogicScript logic;
    public float spawnRate = 0;
    private float timer = 0;
    public float widthoffset = 0;

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

    {
  
        if (logic.playerScore > 85)
        {

           
            float lowestPoint = transform.position.x - widthoffset;
            float highestPoint = transform.position.x + widthoffset;
            Instantiate(Icespikes,new Vector3(Random.Range(lowestPoint, highestPoint), 100, 0), transform.rotation);
        }

    }
   
}
