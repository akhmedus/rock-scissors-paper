using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    [SerializeField]
    Material playerMaterial;

    [SerializeField]
    Material enemyMaterial;

    [SerializeField]
    GameObject[] gameObjects;
    [SerializeField]
    GameObject[] gameClones;

    [ContextMenu("Clone")]
    void Clone() 
    {
        gameClones = new GameObject[gameObjects.Length];

        for (int i = 0; i < gameObjects.Length; i++) 
        {
            gameClones[i] = Instantiate(gameObjects[i], gameObjects[i].transform.position,
                gameObjects[i].transform.rotation, gameObjects[i].transform);

            gameClones[i].transform.localScale = Vector3.one;
            gameClones[i].GetComponent<Renderer>().material = playerMaterial;
        }
    }

    public void SetMaterial(Side side) 
    {
        Material material = playerMaterial;

        if (side == Side.Enemy) 
        {
            material = enemyMaterial;
        }

        for (int i = 0; i < gameClones.Length; i++) 
        {
            gameClones[i].GetComponent<Renderer>().material = material;
        }
    }
}
