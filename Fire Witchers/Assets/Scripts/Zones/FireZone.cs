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
        while (true)
        {
            yield return new WaitForSeconds(1);
            Witches.ForEach(w => w.UpdateEnergy(-EnergyCost)); 
            
            List<Witch> witchesToRemove = Witches.FindAll(w => w.CurrentEnergy <= 0);
            witchesToRemove.ForEach(w => RemoveWitch(w));
        }
    }
}
