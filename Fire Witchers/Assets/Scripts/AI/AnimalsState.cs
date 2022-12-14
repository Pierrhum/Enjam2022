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
        _witch.Animator.SetBool("Back", true);
        
        if (_witch.CurrentZone == null
        || _witch.CurrentZone.Type != ZoneType.ANIMALS) return typeof(WaitingState);
        return null;
    }
}
