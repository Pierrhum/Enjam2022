using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : BaseState
{

    public FireState(Witch witch) : base(witch)
    {
    }

    public override Type Tick()
    {
        _witch.Animator.SetBool("Back", true);
        if (_witch.CurrentZone == null ||
            _witch.CurrentZone.Type != ZoneType.FIRE) return typeof(WaitingState);
        
        return null;
    }
}
