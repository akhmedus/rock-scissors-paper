using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Side 
{
    Player,
    Enemy
}

public enum Type 
{
    Rock,
    Paper,
    Scissor,
    None
}
public class ArenaObject : MonoBehaviour
{
    [Header("ArenaObject")]
    public Side side;

    protected UnitManager unitManager;
    GameObject enemyCircle;

    public Type Type;
    public virtual void Setup(UnitManager manager) 
    {
        side = manager.side;
        if (side == Side.Enemy)
        {
            enemyCircle.SetActive(true);

        }
        else 
        {
            enemyCircle.SetActive(false);
        }
        manager.AddOne(this);
        unitManager = manager;
    }

    public virtual void Die() 
    {
        unitManager.RemoveOne(this);
    }


    public virtual void TakeDamage(Unit unit) 
    { 
    }
}
