using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject BackGround1;
    public GameObject BackGround2;
    public GameObject BackGround3;
    public LogicScript logic;
    void Start()
    {
        BackGround1.SetActive(true);
        BackGround2.SetActive(false);
        BackGround3.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (logic.playerScore == 20)
        {
            BackGround1.SetActive(false);
            BackGround2.SetActive(true);
        }
        if (logic.playerScore == 50)
        {
            BackGround1.SetActive(false);
            BackGround2.SetActive(false);
            BackGround3.SetActive(true);
        }
    }
}
