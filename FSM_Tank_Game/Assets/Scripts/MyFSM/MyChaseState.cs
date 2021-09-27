using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyChaseState : MyState
{
    private Transform player;
    protected Vector3 destPos;
   

    public float curRotSpeed = 1.0f;
    public float curSpeed = 100.0f;
    public float attackDistance = 100f;
    public float loseDistance = 300f;

    private float dist;
    public MyChaseState() : base()
    {
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Awake()
    {
        base.Awake();


    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        Debug.Log(tank.health);
        base.OnEnable();
        AddTransition<MyAttackState>(() => dist <= attackDistance);
        AddTransition<MyPatrolState>(() => dist > loseDistance);
        AddTransition<MyDeadState>(() => tank.health <= 0);
        AddTransition<MyRecoverState>(() => tank.health <= 50);
    }

    public override void Update()
    {
        base.Update();

        player = GameObject.FindGameObjectWithTag("player").transform;
        dist = Vector3.Distance(destPos, tank.transform.position);


        //Rotate to the target point
        destPos = player.position;
       

        Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        //Go Forward
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
        Debug.Log("Chasing");
        
    }

}
