using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState : BaseState
{
    private float radius;
    private SpawnZone SpawnZone;
    public SpawnState(Witch witch) : base(witch)
    {
    }

    public override Type Tick()
    {
        if (_witch.CurrentZone == null ||
            _witch.CurrentZone.Type != ZoneType.ZAWN) return typeof(WaitingState);

        if (!_witch.isDragged)
        {
            if(SpawnZone == null)
            {
                SpawnZone = ((SpawnZone)_witch.CurrentZone);
                _witch.transform.position = SpawnZone.transform.position + Vector3.right * (SpawnZone.width / 2f);
            }
            _witch.transform.RotateAround(SpawnZone.transform.position, Vector3.forward * Time.deltaTime, 0.2f);
            Vector3 dir = SpawnZone.transform.position - _witch.transform.position;
            float angle = 90 + Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            _witch.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            _witch.transform.eulerAngles = Vector3.zero;
            SpawnZone = null;
        }
        
        return null;
    }
}
