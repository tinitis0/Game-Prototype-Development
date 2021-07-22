using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour {

    public Text GoldText;


    void Update() 
    {
        GoldText.text = "£" + Currency.Gold.ToString();
    }


}
