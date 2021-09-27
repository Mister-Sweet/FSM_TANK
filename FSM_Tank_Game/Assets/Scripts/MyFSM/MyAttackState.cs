using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAttackState : MyState
{
    public float shootRate;
    public GameObject Bullet;
    public float curRotSpeed;

    private Transform player;
    protected Vector3 destPos;

    private float elapsedTime;
    private Transform bulletSpawnPoint;
    private float dist;

    public override void Awake()
    {
        base.Awake();

        elapsedTime = 0.0f;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log(tank.health);
        AddTransition<MyChaseState>(() => dist >= 200.0f && dist < 300.0f);
        AddTransition<MyPatrolState>(() => dist > 300f);
        AddTransition<MyRecoverState>(() => tank.health <= 50);
        AddTransition<MyDeadState>(() => tank.health <= 0);
    }

    public override void Update()
    {
        base.Update();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dist = Vector3.Distance(player.position, tank.transform.position);

        elapsedTime += Time.deltaTime;
        destPos = player.position;

        //Always Turn the turret towards the player
        Transform turret = tank.transform.GetChild(0).transform;
        bulletSpawnPoint = turret.GetChild(0).transform;
        Quaternion turretRotation = Quaternion.LookRotation(destPos - turret.position);
        turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * curRotSpeed);
        Debug.Log("Attacking");

        ShootBullet();
    }

    public void ShootBullet()
    {
        if (elapsedTime >= shootRate)
        {
            Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            elapsedTime = 0.0f;
        }
    }
}
