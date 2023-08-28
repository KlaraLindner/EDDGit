using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
public class MouseInteraktion : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject grasUI;
    [SerializeField] GameObject treeUI;
    [SerializeField] GameObject leavesUI;
    [SerializeField] GameObject berriesUI;
    [SerializeField] GameObject animalsUI;

    [SerializeField] RawImage currentDraggable;
    [SerializeField] RawImage clickedUIElement;
    [SerializeField] EventSystem ev;
    public UnityEvent FoxInteraction = new UnityEvent();
 
    void Update()
    {   //If the left mousebutton is pressed, 
        //SHoot a raycast and check, if an Object was hit


        if (IsValidCurrentDraggable()&&clickedUIElement)
        {        
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("DraggableDetected! setting clicked UI Element active "+ clickedUIElement);
                SetCurrentDraggableActive(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                SetCurrentDraggableActive(false);
                clickedUIElement = null;
            }
        }

        if (Input.GetMouseButton(0)&&clickedUIElement)
        {


            currentDraggable.rectTransform.position = Input.mousePosition;
        }
        if ((Input.GetMouseButtonDown(0)))
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
     bool IsValidCurrentDraggable()
    {
        if (ev.IsPointerOverGameObject() && currentDraggable)
            return true;
        return false;
    }
    void SetCurrentDraggableActive(bool active)
    {
        currentDraggable.gameObject.SetActive(active);
        
    }
   public  void SetCurrentDraggable(RawImage draggable)
    {
        clickedUIElement = draggable;
        Debug.Log("Setting texture of Draggable");
        currentDraggable.texture = draggable.texture;
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
   public void ShowOnMouseHover(bool color)
    {
        if (color)
        {
            currentDraggable.color = Color.red;
            return;
        }
        currentDraggable.color = Color.white;
    }
    public void SetFoxInteraction(FuchsBehaviour foxBehaviour)
    { 
        Debug.Log("Feeding fox with " + clickedUIElement);
        if (clickedUIElement)
        {
            
            foxBehaviour.SetAnimation(clickedUIElement);
            return;
        }
       foxBehaviour.SetAnimation();
    }

    void OnDrawGizmos() {
        Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
