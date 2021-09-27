using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTransition
{
    public Func<bool> condition;
    public MyState targetState;
}


