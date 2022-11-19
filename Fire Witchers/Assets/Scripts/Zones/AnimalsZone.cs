using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsZone : BaseZone
{
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
            Debug.Log(CurrentTime);
            if (CurrentTime % (RequiredTime - (Witches.Count * RemovedTimeByWitch)) == 0)
            {
                GameManager.Instance.AnimalsCount++;
                Debug.Log("NB Animals : " + GameManager.Instance.AnimalsCount);
            }
            CurrentTime ++;
            yield return new WaitForSeconds(1);
        }
        // TODO : Load Win Screen
    }
}
