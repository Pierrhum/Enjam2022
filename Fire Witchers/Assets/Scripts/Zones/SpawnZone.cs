using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : BaseZone
{
    public GameObject WitchPrefab;
    public float width;
    private void Awake()
    {
        Init(ZoneType.ZAWN);
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public void Spawn()
    {
        GameObject go = Instantiate(WitchPrefab);
        go.GetComponent<Witch>().CurrentZone = this;
        AddWitch(go.GetComponent<Witch>());
        GameManager.Instance.CurrentNbWitches++;
    }
    
    protected override IEnumerator ZoneAction()
    {
        yield return null;
    }
}
