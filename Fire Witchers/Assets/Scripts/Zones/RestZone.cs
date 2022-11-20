using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestZone : BaseZone
{
    public int EnergyGain = 2;
    private void Awake()
    {
        Init(ZoneType.REST);
    }

    protected override IEnumerator ZoneAction()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Witches.ForEach(w => w.UpdateEnergy(EnergyGain));
        }
    }
}
