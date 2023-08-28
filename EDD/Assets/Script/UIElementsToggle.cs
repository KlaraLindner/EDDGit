using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementsToggle : MonoBehaviour
{
    [SerializeField] GameObject activeElement;

    GameObject lastActive ;

    public void SetTextActive(GameObject activeObject)
    {
        if (lastActive)
            lastActive.SetActive(false);
        activeObject.SetActive(true);
        lastActive = activeObject;
        activeElement = activeObject;
    }

    public void SetTextDeactive()
    {
        if (lastActive)
            lastActive.SetActive(false);   
    }

}
