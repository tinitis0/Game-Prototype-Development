using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Level3: MonoBehaviour
{

    private string levelToLoad = "Level3";

    public void Select()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
