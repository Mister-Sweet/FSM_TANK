using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyState : MonoBehaviour
{

    private List<MyTransition> transitions;
    protected TankController tank;

    public virtual void Awake()
    {
        tank = GetComponent<TankController>();
    }

    public virtual void Start()
    {
    }

    public virtual void OnEnable()
    {
        transitions = new List<MyTransition>();
    }

    public virtual void OnDisable()
    {

    }

    public virtual void Update()
    {

    }

    protected void LateUpdate()
    {
        Debug.Log(transitions.Count);

        foreach (MyTransition t in transitions)
        {
            // if (t.condition.Test())
            if (t.condition())
            {
                t.targetState.enabled = true;
                enabled = false;
                return;
            }
        }
    }

    public void AddTransition<StateType>(Func<bool> condition) where StateType : MyState
    {
        MyTransition newTransition = new MyTransition
        {
            targetState = GetComponent<StateType>(),
            condition = condition
        };
        transitions.Add(newTransition);
    }




}
