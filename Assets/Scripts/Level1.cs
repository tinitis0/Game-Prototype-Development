using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour {

    public string levelToLoad = "Level1";

    public void Select()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
