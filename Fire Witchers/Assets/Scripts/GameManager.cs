using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int AnimalsCount = 0;
    public int AnimalsRequired = 2;
    public static GameManager Instance;
    public int MaxNbWitches = 10;
    [System.NonSerialized] public int CurrentNbWitches = 3;

    public List<BaseZone> Zones;
    public HUD _HUD;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _HUD.SetAnimalText(AnimalsCount + " / " + AnimalsRequired);
    }

    public void IncrAnimals()
    {
        AnimalsCount++;
        _HUD.SetAnimalText(AnimalsCount + " / " + AnimalsRequired);

        if (AnimalsCount == AnimalsRequired)
        {
            //TODO : Load Win Screen
        }
    }
}
