using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public static bool gameOver ;

    public GameObject gameOverUI;

    public string nextLevel = "Level2";
    public int nextLevelIndex = 3;

    public SceneManager NextScene; 

    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (gameOver)
            return;

        
        if (Lives.Hearts <= 0)
        {
            EndGame();
        }
	}


    void EndGame()
    {
        gameOver = true;


        gameOverUI.SetActive(true);
    }
    public void WinLevel()
    {
        WaveSpawner.EnemiesLeft = 0;
        Debug.Log("Level WON!!!");
        PlayerPrefs.SetInt("reachedLevel", nextLevelIndex);
        SceneManager.LoadScene("Level Chooser");
    }

}
