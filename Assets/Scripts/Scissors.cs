using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Scissors : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent nav;
    [SerializeField]
    Vector3 targetPoint;

    public void StartDrag() 
    {
        
    }

    public void Place() 
    {
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(targetPoint);
    }
}
