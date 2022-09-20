using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLine : MonoBehaviour
{

    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField]
    Transform endObject;

    // Start is called before the first frame update
    void Start()
    {
        Hide();
        
    }

    void Set(Vector3 start, Vector3 end) 
    {
        lineRenderer.enabled = true;
        endObject.gameObject.SetActive(true);
        lineRenderer.SetPosition(0, start + Vector3.up * 0.04f);
        lineRenderer.SetPosition(1, end + Vector3.up * 0.04f);
    }


    public void Hide() 
    {
        lineRenderer.enabled = false;
        endObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
