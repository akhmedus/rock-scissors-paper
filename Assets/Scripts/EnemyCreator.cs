using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField]
    Resources resources;
    [SerializeField]
    Unit[] unitPrefs;

    [SerializeField]
    CreationZone startZone,allZone;
    [SerializeField]
    GameObject testPref;

    [SerializeField]
    UnitManager unitManager;
    [SerializeField]
    float creationPeriod = 1;

    float timer;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > creationPeriod) 
        {
            timer = 0;
            RandomUnit();
        }        
    }

    void RandomUnit() 
    {
        int index = Random.Range(0, unitPrefs.Length);

        
    }

}
