using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MouseInteraktion : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject grasUI;
    [SerializeField] GameObject treeUI;
    [SerializeField] GameObject leavesUI;
    [SerializeField] GameObject berriesUI;
    [SerializeField] GameObject animalsUI;

    [SerializeField] EventSystem ev;
    void Start()
    {
       
    }

    void Update()
    {   //If the left mousebutton is pressed, 
        //SHoot a raycast and check, if an Object was hit

  
        if (Input.GetMouseButtonDown(0))
        {
            if (ev.IsPointerOverGameObject())
                return;
            Debug.Log("MouseHIt");
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mousePosition, out RaycastHit hitInfo, 100f))
            {
                Debug.Log("Hit " + hitInfo);
                SortEnviromentItems(hitInfo.transform.gameObject.layer);
            }
        }
    }

    void SortEnviromentItems(LayerMask layer)
    {
        switch (layer.value)
        {
            case 6: grasUI.SetActive(true); break;
            case 7: treeUI.SetActive(true); break;
            case 8: leavesUI.SetActive(true); break;
            case 9: berriesUI.SetActive(true); break;
            case 10:animalsUI.SetActive(true); break;
            default: break;

        }
    }
    void OnDrawGizmos() {
        Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
