using UnityEngine.UI;
using UnityEngine;

public class ChooseLevel : MonoBehaviour {

    public Button[] levelButtons;

	// Use this for initialization
	void Start () {

        int reachedLevel = PlayerPrefs.GetInt ("reachedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {

            if (i + 1 > reachedLevel)
                levelButtons[i].interactable = false;
        }
	}
	
	
}
