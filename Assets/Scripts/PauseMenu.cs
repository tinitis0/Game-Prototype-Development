using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
	}

    public void Toggle()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf); // when its enabled its true, when disabled it flips and disables the menu

        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0f; // freezes the delta time

        }
        else
        {
            Time.timeScale = 1f; // returns to normal game speed
        }
    }

    public void Restart()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
