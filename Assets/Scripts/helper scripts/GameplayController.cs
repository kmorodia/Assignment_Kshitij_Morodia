using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    //public GameObject food_Pickup;

    private float min_X = -16f, max_X = 18f, min_Y = -12f, max_Y = 10f;
    private float z_Pos = 0f;

    private Text score_Text;
    private Text streak_Text;
    private int scoreCount;
    
    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        score_Text = GameObject.Find("Score").GetComponent<Text>();
        streak_Text = GameObject.Find("AddedScore").GetComponent<Text>();
        Invoke("StartSpawning", 0.5f);
    }

    void MakeInstance() {
        if (instance == null){
            instance = this;
        }
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnPickups());
    }

    public void CancelSpawning()
    {
        CancelInvoke("StartSpawning");
    }

    IEnumerator SpawnPickups()
    {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));

        SpawnFood();

        Invoke("StartSpawning", 0f);
        
    }

    public void SpawnFood()
    {
        Instantiate(FoodSpawner.instance.getSpawn().foodColor,
                    new Vector3(Random.Range(min_X, max_X),
                                Random.Range(min_Y, max_Y), z_Pos),
                                Quaternion.identity);
    }
    public void IncreaseScore(int incScore)
    {
        scoreCount+=incScore;
        score_Text.text = "Score: " + scoreCount;
        streak_Text.text = "+ " + incScore + " !";
    }

    public int getScoreCount()
    {
        return scoreCount;
    }

}
