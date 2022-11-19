using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int AnimalsCount = 0;
    public int AnimalsRequired = 2;
    public static GameManager Instance;

    public FireZone FireZone;
    public AnimalsZone AnimalZone;
    private void Awake()
    {
        Instance = this;
    }
}
