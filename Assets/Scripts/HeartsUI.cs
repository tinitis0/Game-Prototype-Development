using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour {


    public Text heartsText;

	
	// Update is called once per frame
	void Update () {
        heartsText.text = "Hearts Left:" + Lives.Hearts.ToString(); // changes the heart amount on the heart counter
	}
}
