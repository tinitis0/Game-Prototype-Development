using UnityEngine;


public class Waypoints : MonoBehaviour
{

    public static Transform[] Markers;  // static doesnt need reference from script, can be accessed from anywhere

    void Awake()
    {
        Markers = new Transform[transform.childCount];
        for (int i = 0; i < Markers.Length; i++)  // creates 13 spaces for 13 waypoints, then loop throught them in the order
        {
            Markers[i] = transform.GetChild(i);
        }
    }

}
