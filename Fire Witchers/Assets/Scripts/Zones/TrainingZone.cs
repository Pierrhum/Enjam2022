using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingZone : BaseZone
{
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
                Debug.Log("SPAWN Witch");
            }
            CurrentTime ++;
            yield return new WaitForSeconds(1);
        }
    }
}
