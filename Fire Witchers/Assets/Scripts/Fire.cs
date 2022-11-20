using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public int MaxStep = 50;
    public int StartStepSec = 8;
    public int MidStepSec = 5;
    public Image FireBarFill;

    [SerializeField] private FireZone _FireZone;
    private float CurrentTime = 0;
    private int CurrentStep = 0;

    private void Start()
    {
        Begin();
    }

    public void Begin()
    {
        StartCoroutine(FireCoroutine());
    }

    private IEnumerator FireCoroutine()
    {
        while (CurrentStep < MaxStep)
        {
            int StepTime = CurrentStep >= MaxStep / 2 ? MidStepSec : StartStepSec;
            
            if (CurrentTime > StepTime + _FireZone.GetReducedTime())
            {
                CurrentStep++;
                CurrentTime = 0f;
            }
            
            FireBarFill.fillAmount = (float) CurrentStep / MaxStep + CurrentTime / ((StepTime + _FireZone.GetReducedTime()) * MaxStep);
            CurrentTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}