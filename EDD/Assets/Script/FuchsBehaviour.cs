using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuchsBehaviour : RandomAnimalMovement
{
    [SerializeField] Animator fuchsAnimator;
    Vector3 localDir;
    Vector3 rayoffset;
    float yHitPoint;
    RaycastHit hit;
    Vector3 startDir;
    float currentYHit = 0f;
    Vector2 hitAhead;
    // Start is called before the first frame update
    void Start()
    {
        if (!fuchsAnimator)
            Debug.LogError("No animator Linked, animatons wont work properly!");
        startDir=transform.TransformDirection(0, -1f, 1f);
    }
    protected override void Update()
    {
        base.Update();

        localDir = startDir;
        rayoffset = new Vector3(transform.position.x, transform.position.y+1, transform.position.z + 1f);
        Vector2 twoAxisforward = new Vector2(transform.forward.x, transform.forward.z);
        if (Physics.Raycast(rayoffset, localDir, out hit, 5f,1<<3))
        {
            Debug.Log("Hitahead!");
            hitAhead = new Vector2(hit.point.y, hit.point.z);
            Vector2 posXY = new Vector2(transform.position.y, transform.position.z);
            Vector2 forwardXY = new Vector2(transform.forward.y, transform.forward.z);
            Vector3 changeingVector = new Vector3(transform.forward.x, hit.point.y - transform.position.y, transform.forward.z);

            Vector2 twoAxisDir = new Vector2(currentDir.x, currentDir.z);
           float trundir= Mathf.LerpAngle(transform.localEulerAngles.y, Vector2.SignedAngle(twoAxisDir, twoAxisforward), Time.deltaTime);
            
            float rotX = Mathf.LerpAngle(transform.localEulerAngles.x, Vector3.SignedAngle(transform.forward, changeingVector, transform.right), Time.deltaTime);
            transform.rotation = Quaternion.Euler(rotX,trundir, 0f);

        }
       
        if (Physics.Raycast(transform.position, -transform.up, out hit, 2f, 1 << 3))
        {
            currentYHit = hit.point.y;
           // transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            
        }

        
        
     //fuchsAnimator.SetFloat("Turn", Vector2.SignedAngle(twoAxisDir, twoAxisforward));
       
     
      
        // fuchsAnimator.SetFloat("Turn", );
    }
    // Update is called once per frame
    private void OnDrawGizmos()
    {
     
       rayoffset= new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1f);
        Gizmos.DrawRay(transform.position, transform.forward);
        Gizmos.color= Color.black;
        if (Physics.Raycast(rayoffset, startDir, out hit, 3f, 1 << 3))
        { Vector3 changeingVector = new Vector3(transform.forward.x,   hit.point.y- transform.position.y, transform.forward.z);
          
            Gizmos.DrawRay(transform.position, changeingVector*3);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(rayoffset, startDir);
           
        }
    }
}
