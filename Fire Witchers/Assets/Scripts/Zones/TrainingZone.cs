using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingZone : BaseZone
{
    public SpawnZone SpawnZone;
    public int EnergyCost = 1;
    public int RequiredTime = 20;
    public int RemovedTimeByWitch = 3;
    private int CurrentTime = 0;
    private void Awake()
    {
        Init(ZoneType.TRAINING);
    }

    protected override IEnumerator ZoneAction()
    {
        while (GameManager.Instance.CurrentNbWitches < GameManager.Instance.MaxNbWitches)
        {
            if (CurrentTime % (RequiredTime - (Witches.Count * RemovedTimeByWitch)) == 0)
            {
                SpawnZone.Spawn();
            }
            CurrentTime ++;
            Witches.ForEach(w => w.UpdateEnergy(-EnergyCost));
                
            List<Witch> witchesToRemove = Witches.FindAll(w => w.CurrentEnergy <= 0);
            witchesToRemove.ForEach(w => RemoveWitch(w));
            yield return new WaitForSeconds(1);
        }
    }
}
