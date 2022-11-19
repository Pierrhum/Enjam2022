using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZone : BaseZone
{
    private void Awake()
    {
        Init(ZoneType.FIRE);
    }

    protected override IEnumerator ZoneAction()
    {
        throw new NotImplementedException();
    }
}
