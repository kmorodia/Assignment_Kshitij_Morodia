using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public static bool gameHasEnded = false;

    public GameObject endMenuUI;
    public Text scoreUI;

    void Update()
    {
        if (gameHasEnded)
        {
            scoreUI.text = "Score: " + GameplayController.instance.getScoreCount();
            endMenuUI.SetActive(true);
        }
    }

    public void goBack()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
