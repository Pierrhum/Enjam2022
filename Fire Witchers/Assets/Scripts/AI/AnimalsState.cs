using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsState : BaseState
{
    public AnimalsState(Witch witch) : base(witch)
    {
    }

    public override Type Tick()
    {
        Debug.Log("AnimalsState");
        
        if (_witch.CurrentZone.Type != ZoneType.ANIMALS) return typeof(WaitingState);
        return null;
    }
}
