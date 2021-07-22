using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFace : MonoBehaviour
{
    void Start()
    {
        transform.rotation = Quaternion.Euler(270, 270, 0);
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(270, 270, 0);
    }
}
