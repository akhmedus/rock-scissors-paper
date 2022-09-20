using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

    [SerializeField]
    List<ArenaObject> arenaObjects = new List<ArenaObject>();
    public Side side;
    public UnitManager Oponent;

    // Start is called before the first frame update
    void Start()
    {
        ArenaObject[] objects = FindObjectsOfType<ArenaObject>();
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].side == side)
            {
                arenaObjects[i].Setup(this);
            }
        }
        
    }

    public ArenaObject GetClosest(Vector3 pos, float distToSelect,Type type) 
    {
        float closestDist = Mathf.Infinity;
        ArenaObject closestArenaObject = null;

        for (int i = 0; i < arenaObjects.Count; i++) 
        {
            if (arenaObjects[i].Type == type)
            {
                float dist = Vector3.Distance(arenaObjects[i].transform.position, pos);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closestArenaObject = arenaObjects[i];
                }
            }
        }

        if (closestDist < distToSelect)
        {
            return closestArenaObject;
        }
        else 
        {
            return null;
        }
    }

    public void RemoveOne(ArenaObject arenaObject) 
    {
        arenaObjects.Remove(arenaObject);
    }

    public void AddOne(ArenaObject arenaObject) 
    {
        arenaObjects.Add(arenaObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
