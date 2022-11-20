using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingState : BaseState
{

    public TrainingState(Witch witch) : base(witch)
    {
    }

    public override Type Tick()
    {
        if (_witch.CurrentZone == null ||
         _witch.CurrentZone.Type != ZoneType.TRAINING) return typeof(WaitingState);
        return null;
    }
}
