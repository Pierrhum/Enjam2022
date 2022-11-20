using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : BaseZone
{
    public GameObject WitchPrefab;
    private void Awake()
    {
        Init(ZoneType.ZAWN);
    }

    public void Spawn()
    {
        Instantiate(WitchPrefab, transform);
    }
    
    protected override IEnumerator ZoneAction()
    {
        throw new System.NotImplementedException();
    }
}
