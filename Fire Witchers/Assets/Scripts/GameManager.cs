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
    public FireZone FireZone;
    public AnimalsZone AnimalZone;
    public TrainingZone TrainingZone;
    public SpawnZone SpawnZone;
    public RestZone RestZone;
    private void Awake()
    {
        Instance = this;
    }
}
