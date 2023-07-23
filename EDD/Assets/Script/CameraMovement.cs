using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CameraMovement : MonoBehaviour
{
    [Range(0.1f, 1f)]
    [SerializeField] float accreleration;
    [SerializeField] Camera mainCam = null;
    [SerializeField] EventSystem ev;
    float screenspaceX;
    float screenspaceY;
    float normalizedMousePosX;
    float normalizedMousePosY;
    // Start is called before the first frame update
    void Start()
    {
        screenspaceX = Screen.width;
        screenspaceY = Screen.height;
    }

    void Update()
    {
        RotateCam();
    }
    //Screenspce .x
    void RotateCam()
    {

        if (ev.IsPointerOverGameObject())
            return;
        normalizedMousePosX = (1 - (Input.mousePosition.y / screenspaceY)) - 0.5f;
        normalizedMousePosY = (Input.mousePosition.x / screenspaceX) - 0.5f;
        //Memo: Gimble Lock example from Varanasis lectrue
        // Rotation axis is x up and down, y is left and right, so screenspace iverted!
        //-1 on y because when moving up, the camera moves down  

       // mainCam.transform.eulerAngles += new Vector3(normalizedMousePosX, normalizedMousePosY, 0f) * accreleration;
        //Correct implementation;
        // mainCam.transform.rotation *= Quaternion.Euler((1 - (Input.mousePosition.y / screenspaceY)) - 0.5f, (Input.mousePosition.x / screenspaceX) - 0.5f, 0f);
        //I don't know whats happening here, engine magic in the 4th dimension I guess
        //mainCam.transform.rotation *= new Quaternion(normalizedMousePosX, normalizedMousePosY, 0f, 100 - (accreleration * 30));
        //Short hand:
         mainCam.transform.Rotate(new Vector3(normalizedMousePosX, normalizedMousePosY, 0f) * accreleration);
        //Constant Rotatition alters the z-axis, this needs to be reseted every frame
        mainCam.transform.eulerAngles = new Vector3(mainCam.transform.eulerAngles.x, mainCam.transform.eulerAngles.y, 0f);
     }
}
