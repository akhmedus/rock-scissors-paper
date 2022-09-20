using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreator : MonoBehaviour
{
    [SerializeField]
    Unit currentUnit;
    [SerializeField]
    Camera cam;

    public void Create(Unit unit) 
    {
        Instantiate(unit);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentUnit) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);
            float dist;
            plane.Raycast(ray, out dist);
            Vector3 point = ray.GetPoint(dist);
            
            currentUnit.transform.position = point;

            if (Input.GetMouseButtonUp(0)) 
            {
                currentUnit.Place();
                currentUnit = null;
            }
        }
    }
}
