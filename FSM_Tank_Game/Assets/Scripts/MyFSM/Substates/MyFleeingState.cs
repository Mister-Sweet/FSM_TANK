using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFleeingState : MyRecoverState
{
    public Transform water;
    public float curRotSpeed;
    public float curSpeed;

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
        base.OnEnable();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        //Rotate to the target point
        var destPos = water.position;

        Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        //Go Forward
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
        Debug.Log("Fleeing");
    }
}
