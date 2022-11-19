using System;
using UnityEngine;

public class WaitingState : BaseState
{
    public WaitingState(Witch witch) : base(witch)
    {
    }

    public override Type Tick()
    {
        Debug.Log("Waiting State");
        if (_witch.CurrentZone != null)
        {
            switch (_witch.CurrentZone.Type)
            {
                case ZoneType.FIRE:
                    return typeof(FireState);
                case ZoneType.REST:
                    break;
                case ZoneType.ANIMALS:
                    return typeof(AnimalsState);
                    break;
                case ZoneType.TRAINING:
                    break;
                case ZoneType.ZAWN:
                    break;
            }
        }
        return null;
    }
}
