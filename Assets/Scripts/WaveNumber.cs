using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNumber : MonoBehaviour
{
  
    public Text WaveN;
    private int wnumber;
    public int maxwave;
   


    void Update()
    {
        wnumber = Rounds.wavesCompleted;
        WaveN.text = "Wave " + wnumber + "/" + maxwave;
    }


}
