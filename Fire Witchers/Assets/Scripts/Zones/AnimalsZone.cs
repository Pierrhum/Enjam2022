using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalsZone : BaseZone
{
    public List<GameObject> AnimalPrefabs;
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
            yield return new WaitForSeconds(1);
            if (CurrentTime % (RequiredTime - (Witches.Count * RemovedTimeByWitch)) == 0)
            {
                GameManager.Instance.IncrAnimals();
                GameObject go = Instantiate(AnimalPrefabs[Random.Range(0, AnimalPrefabs.Count)], transform.position + Vector3.up * 5, Quaternion.identity);
                go.GetComponent<AnimalController>().Activate();
            }
            
            CurrentTime ++;
            Witches.ForEach(w => w.UpdateEnergy(-EnergyCost));
                
            List<Witch> witchesToRemove = Witches.FindAll(w => w.CurrentEnergy <= 0);
            witchesToRemove.ForEach(w => RemoveWitch(w));
        }

        // Load Win Screen
        GameManager.Instance.EndGame(true);
    }
}
