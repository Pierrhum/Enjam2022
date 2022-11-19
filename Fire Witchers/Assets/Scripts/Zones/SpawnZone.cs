using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : BaseZone
{
    private void Awake()
    {
        Init(ZoneType.ZAWN);
    }

    protected override IEnumerator ZoneAction()
    {
        throw new System.NotImplementedException();
    }
}
