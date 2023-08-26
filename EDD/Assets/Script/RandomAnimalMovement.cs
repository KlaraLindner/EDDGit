using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomAnimalMovement : MonoBehaviour
{

    [SerializeField] Collider[] pathPoints;
    [SerializeField] [Range(0.01f,1f)] float movementSpeed;
    [SerializeField] int currentIndexPathPoint = 0;
    [SerializeField] bool lockPosition = false;
    [SerializeField] bool lockRotation = false;
    protected Vector3 currentDir = Vector3.zero;


    void Start()
    {
        if (pathPoints == null)
        {
            Debug.LogError("No paths assignded, path finding wont work!");
            return;
        }
    }

   protected virtual void Update()
    {
      
         currentDir = pathPoints[currentIndexPathPoint].transform.position - transform.position;
        if (!lockPosition)
            transform.Translate(currentDir.magnitude * movementSpeed * Time.deltaTime * Vector3.forward);
       
        if (!lockRotation)
           transform.forward = Vector3.Lerp(transform.forward, currentDir, Time.deltaTime);
    }
          

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter called "+ pathPoints[currentIndexPathPoint].transform.Equals(other.transform));
        if (!pathPoints[currentIndexPathPoint].transform.Equals(other.transform))
                return;
            currentIndexPathPoint++;
        if (currentIndexPathPoint > pathPoints.Length-1)
            currentIndexPathPoint = 0;

    }
    
}
