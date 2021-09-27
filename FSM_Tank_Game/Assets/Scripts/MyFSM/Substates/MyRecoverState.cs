using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRecoverState : MyState
{

    public List<MyState> states;
    public MyState stateInitial;
    protected MyState stateCurrent;

    protected Vector3 startPos;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        stateCurrent.enabled = false;
        foreach (MyState s in states)
        {
            s.enabled = false;
        }
    }

    public override void OnEnable()
    {
        base.OnEnable();
        startPos = tank.gameObject.transform.position;
        if (stateCurrent == null)
            stateCurrent = stateInitial;
        stateCurrent.enabled = true;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
