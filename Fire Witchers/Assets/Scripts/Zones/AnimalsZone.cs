using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsZone : BaseZone
{
    public int EnergyCost = 1;
    public int RequiredTime = 30;
    public int RemovedTimeByWitch = 5;
    private int CurrentTime = 0;
    private void Awake()
    {
        Init(ZoneType.ANIMALS);
    }

    protected override IEnumerator ZoneAction()
    {
        while (GameManager.Instance.AnimalsCount < GameManager.Instance.AnimalsRequired)
        {
            if (CurrentTime % (RequiredTime - (Witches.Count * RemovedTimeByWitch)) == 0)
                GameManager.Instance.IncrAnimals();
            
            CurrentTime ++;
            Witches.ForEach(w => w.UpdateEnergy(-EnergyCost));
                
            List<Witch> witchesToRemove = Witches.FindAll(w => w.CurrentEnergy <= 0);
            witchesToRemove.ForEach(w => RemoveWitch(w));
            yield return new WaitForSeconds(1);
        }

        // Load Win Screen
        GameManager.Instance.EndGame(true);
    }
}
