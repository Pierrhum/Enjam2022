using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestState : BaseState
{
    public RestState(Witch witch) : base(witch)
    {
    }

    public override Type Tick()
    {
        if (_witch.CurrentZone == null ||
            _witch.CurrentZone.Type != ZoneType.REST) return typeof(WaitingState);
        
        return null;
    }
}
