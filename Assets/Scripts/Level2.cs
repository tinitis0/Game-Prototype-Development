using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{

    private string levelToLoad = "Level2";

    public void Select()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
