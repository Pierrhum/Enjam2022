using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RestZone : BaseZone
{
    public int EnergyGain = 2;
    public GameObject Chaudron;
    public GameObject ActiveWitch;
    
    private void Awake()
    {
        Init(ZoneType.REST);
    }

    protected override IEnumerator ZoneAction()
    {
        while (true)
        {
            Chaudron.SetActive(Witches.Count == 0);
            if (Witches.Count > 0)
            {
                ActiveWitch.SetActive(true);
                Witches[0].gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(1);
            Witches.ForEach(w => w.UpdateEnergy(EnergyGain));
        }
    }
    
    public void OnClick(BaseEventData data)
    {
        Chaudron.SetActive(true);
        ActiveWitch.SetActive(false);
        Witches[0].gameObject.SetActive(true);
        Witches.Clear();
    }
}
