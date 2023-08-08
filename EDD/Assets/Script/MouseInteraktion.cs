using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraktion : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    void Start()
    {
        
    }

    void Update()
    {   //If the left mousebutton is pressed, 
        //SHoot a raycast and check, if an Object was hit
       
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MouseHIt");
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if(Physics.Raycast(mousePosition, out RaycastHit hitInfo, 100f))
            {
                Debug.Log("Hit " + hitInfo.transform.name);
            }
        }
    }
}
