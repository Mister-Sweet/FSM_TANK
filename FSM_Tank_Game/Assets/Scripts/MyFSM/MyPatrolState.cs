using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPatrolState : MyState
{
    
    public MyPatrolState() : base()
    {
    }

    public List<Transform> waypoints;

    public float spotDistance = 100f;
    public float curRotSpeed = 1.0f;
    public float curSpeed = 100.0f;

    private Transform player;
    protected Vector3 destPos;



    private float distance;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        Debug.Log("Start");
        base.Start();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log(tank.health);
        AddTransition<MyChaseState>(() => distance < spotDistance);
        AddTransition<MyDeadState>(() => tank.health <= 0);
        AddTransition<MyRecoverState>(() => tank.health <= 50);
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Patrolling");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        distance = Vector3.Distance(player.position, transform.position);
        Debug.Log(distance);

        if (distance > spotDistance)
        {
            FindNextPoint();
            Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);
            transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
        }
    }

    public void FindNextPoint()
    {
        //Debug.Log("Finding next point");
        int rndIndex = Random.Range(0, waypoints.Count);
        Vector3 rndPosition = Vector3.zero;
        destPos = waypoints[rndIndex].position + rndPosition;
    }
}
