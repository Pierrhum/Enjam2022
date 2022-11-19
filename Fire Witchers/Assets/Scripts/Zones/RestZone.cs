using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestZone : BaseZone
{
    private void Awake()
    {
        Init(ZoneType.REST);
    }

    protected override IEnumerator ZoneAction()
    {
        throw new System.NotImplementedException();
    }
}
