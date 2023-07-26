using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuchsBehaviour : MonoBehaviour
{
    [SerializeField] Animator fuchsAnimator;
    [Range(0.01f, 0.1f)]
    [SerializeField] float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        if (!fuchsAnimator)
            Debug.LogError("No animator Linked, animatons wont work properly!");
    }

    // Update is called once per frame

}
