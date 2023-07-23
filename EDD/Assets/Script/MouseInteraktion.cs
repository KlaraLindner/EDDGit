using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraktion : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {   //If the left mousebutton is pressed, 
        //SHoot a raycast and check, if an Object was hit
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 100f, 3))
            {
                Debug.Log("Hit " + hitInfo.transform.name);
            }
        }
    }
}
