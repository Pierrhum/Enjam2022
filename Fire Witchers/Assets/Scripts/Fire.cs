using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Fire : MonoBehaviour {
    public FireSpawner spawner;
    public AudioSource Fire1;
    public AudioSource Fire2;
    public AudioSource Fire3;
    public AudioSource Music1;
    public AudioSource Music2;
    public AudioSource Music3;
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
                if(CurrentStep%5==0) spawner.SpawnFlames(CurrentStep <= MaxStep / 2 ? 10 : 
                                                        CurrentStep+10 > MaxStep ? 30 : 20);
                if (CurrentStep == MaxStep / 2)
                {
                    Music1.Stop();
                    Music2.Stop();
                    Music3.Play();
                    Fire2.Play();
                }
                else if(CurrentStep==MaxStep-10) Fire3.Play();
                CurrentTime = 0f;
            }
            
            FireBarFill.fillAmount = (float) CurrentStep / MaxStep + CurrentTime / ((StepTime + _FireZone.GetReducedTime()) * MaxStep);
            CurrentTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        GameManager.Instance.EndGame(false);
    }
}
