using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text waveNumber;

    void OnEnable()
    {
        waveNumber.text = Rounds.wavesCompleted.ToString(); // when game is over this desplays how many waves were completed
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // gets the current scene and starts it again
    }

    public void MainMenu()
    {
        
    }

}
