using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CameraControls : MonoBehaviour
{
    [Header("Camera Movement")]

    private bool movement = true;
    public float cameraspeed = 5f;
    public float border = 10f;

    [Header("Camera Scrolling")]

    public float scrolling = 5f;
    public float minY = 20;
    public float maxY = 100;



    // Update is called once per frame
    void Update()
    {
        if (Manager.gameOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))// pressing left shift will stop the camera from moving and scrolling. pressing it again will allow to move it again
            movement = !movement;

        if (!movement)
            return;

        // preseing WASD keys or moving mouse to side of the screen will move the camera the opposite way. 
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - border)
        {
            transform.Translate(Vector3.back * cameraspeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= border)
        {
            transform.Translate(Vector3.right * cameraspeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= border)
        {
            transform.Translate(Vector3.forward * cameraspeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - border)
        {
            transform.Translate(Vector3.left * cameraspeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel"); // scrolling in mouse wheel will zoom in and out the camera
        Vector3 pos = transform.position;

        pos.y -= scroll * 500 * scrolling * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}