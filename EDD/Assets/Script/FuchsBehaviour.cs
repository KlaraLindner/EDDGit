using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuchsBehaviour : RandomAnimalMovement
{
    [SerializeField] Animator fuchsAnimator;
    // Start is called before the first frame update
    void Start()
    {
        if (!fuchsAnimator)
            Debug.LogError("No animator Linked, animatons wont work properly!");
    }
    protected override void Update()
    {
        base.Update();
        Debug.Log(" "+currentDir);
        Vector3 currentLerpDir =Vector3.Lerp(transform.forward, currentDir, Time.deltaTime);
        Debug.Log("Angle "+Vector3.SignedAngle(currentLerpDir, transform.forward, Vector3.up));

        fuchsAnimator.SetFloat("Turn", Vector3.SignedAngle(currentDir, transform.forward, Vector3.up));
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        // fuchsAnimator.SetFloat("Turn", );
    }
    // Update is called once per frame

}
