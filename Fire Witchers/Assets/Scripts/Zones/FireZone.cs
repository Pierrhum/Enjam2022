using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZone : BaseZone
{
    public int EnergyCost = 2;
    public int ReducedTimeByWitches = 2;
    private void Awake()
    {
        Init(ZoneType.FIRE);
    }

    public int GetReducedTime()
    {
        return Witches.Count * ReducedTimeByWitches;
    }

    protected override IEnumerator ZoneAction()
    {
        // TODO : Baisser stamina witches
        yield return null;
    }
}
