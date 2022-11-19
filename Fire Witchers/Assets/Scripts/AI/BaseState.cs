using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState
{
    protected Witch _witch;
    protected Transform transform;
    
    public BaseState(Witch witch)
    {
        this._witch = witch;
        this.transform = _witch.transform;
    }

    public abstract Type Tick();
}