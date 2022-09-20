using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CreationZone : MonoBehaviour
{
    public float max_x;
    public float max_z;
    public float min_z;

    [SerializeField]
    private RectTransform imageRect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float size_y = max_z - min_z;
        float y = min_z + size_y / 2f;

        imageRect.localPosition = new Vector3(0, y, 0);
        imageRect.sizeDelta = new Vector2(max_x * 2f, size_y);
    }

}
