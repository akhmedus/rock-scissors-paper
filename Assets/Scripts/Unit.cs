using System.Collections;
using System.Collections.Generic;


#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum State 
{
    idle,
    walktoArena,
    walktoPoint
}


public class Unit : ArenaObject
{
    [Header("Unit")]
    public int Price;

    NavMeshAgent nav;
    Collider cldr;
    Vector3 targetPoint;
    State currentState;

    float followDist = 3;
    float attackDist = 1;
    ArenaObject targetArena;

    float walkSpeed = 2;
    float runSpeed = 3;
    bool active = false;
    
    GameObject attackEffect;

    UnityEvent onSelect;
    UnityEvent onUnSelect;

    [SerializeField]
    float targetPos = 0.2f;
    
    void OnValidate()
    {
        if (Application.isPlaying == false) 
        {
            cldr.enabled = side == Side.Player;
            GetComponent<Outline>().SetMaterial(side);
            
        }
    }



    public void StartDrag() 
    {
        nav.enabled = false;
        cldr.enabled = false;
    }

    public void Place() 
    {
        nav.enabled = true;
        cldr.enabled = true;
        onUnSelect?.Invoke();
        
    }

    void Start()
    {
        nav.speed = walkSpeed;
    }

    public override void Setup(UnitManager unitManager) 
    {
        base.Setup(unitManager);
        active = true;
        cldr.enabled = side == Side.Player;
        
    }

    public override void TakeDamage(Unit unit)
    {
        base.TakeDamage(unit);
        Die();
    }



    public Type GetOponent() 
    {
        if (Type == Type.Rock)
        {
            return Type.Scissor;
        }
        else if (Type == Type.Scissor)
        {
            return Type.Paper;
        }
        else if (Type == Type.Paper)
        {
            return Type.Rock;
        }
        else 
        {
            return Type.None;
        }
    } 

    public void Select() 
    {
        onSelect?.Invoke();
    }
    void Update()
    {
        if (!active) 
        {
            return;
        }
        if (currentState == State.idle) 
        {
            Idle();
        }
    }

    void Idle() 
    {
        LookingAround();
    }

    void walkToArena() 
    {
        if (targetArena == null) 
        {
            SetState(State.idle);
            return;
        }
        nav.SetDestination(targetArena.transform.position);

        float dist = Vector3.Distance(transform.position, targetArena.transform.position);

        if (dist < followDist)
        {
            nav.speed = runSpeed;

        }
        else 
        {
            nav.speed = walkSpeed;
        }

        if (dist < attackDist) 
        {
            Attack(targetArena);
        }

    }
    void walkToPoint()
    {
        float dist = Vector3.Distance(transform.position, targetPoint);

        if (dist < targetPos) 
        {
            SetState(State.idle);
        }

        LookingAround();
    }

    void LookingAround() 
    {
        ArenaObject arena = unitManager.Oponent.GetClosest(transform.position, followDist,GetOponent());
        
        if (arena) 
        {
            SetTargetArena(arena);
        }
    }
    void SetState(State state) 
    {
        currentState = state;

        if (currentState == State.idle)
        {
            SetIdle();
        }
        else if (currentState == State.walktoArena)
        {
            SetWalkToArena();
        }
        else if (currentState == State.walktoPoint)
        {
            SetWalkToPoint();
        }
    }


    void SetIdle() 
    {
        nav.speed = walkSpeed;
    }

    void SetWalkToArena()
    {
        nav.speed = walkSpeed;
    }

    void SetWalkToPoint()
    {
        nav.speed = walkSpeed;
    }

    private void OnDrawGizmos()
    {
        if (targetArena) 
        {
            Gizmos.DrawLine(transform.position, targetArena.transform.position);

        }

        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.up, followDist);

        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, attackDist);


    }


    void SetTargetPoint(Vector3 point) 
    {
        onUnSelect?.Invoke();
        
        targetPoint = point;
        nav.SetDestination(point);
        SetState(State.walktoPoint);
    }

    void SetTargetArena(ArenaObject arena) 
    {
        onUnSelect?.Invoke();

        targetArena = arena;
        nav.SetDestination(arena.transform.position);
        SetState(State.walktoArena);
    }

    void Attack(ArenaObject arenaObject) 
    {
        if (attackEffect) 
        {
            GameObject newEffect = Instantiate(attackEffect);

            newEffect.transform.position = arenaObject.transform.position;
        }

        arenaObject.TakeDamage(this);
    }
}
