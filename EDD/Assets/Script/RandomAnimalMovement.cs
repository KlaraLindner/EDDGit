using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomAnimalMovement : MonoBehaviour
{
    [SerializeField] RandomAnimalMovement rAM;
    [SerializeField] Collider[] pathPoints;
    [SerializeField] [Range(0.01f,1f)] float movementSpeed;
    [SerializeField] int currentIndexPathPoint = 0;
    void Start()
    {
        rAM = this;
        if (pathPoints == null)
        {
            Debug.LogError("No paths assignded, path finding wont work!");
            return;
        }
    }


    void Update()
    {
        Vector3 currentDir = pathPoints[currentIndexPathPoint].transform.position - transform.position;
        transform.Translate((Vector3.forward*Time.deltaTime*movementSpeed) * currentDir.magnitude);
       
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
