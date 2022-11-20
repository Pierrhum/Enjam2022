using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {NORMAL, WIN, LOOSE}
public class GameManager : MonoBehaviour
{
    public GameState State = GameState.NORMAL;
    public AudioSource Music;
    public int AnimalsCount = 0;
    public int AnimalsRequired = 2;
    public static GameManager Instance;
    public int MaxNbWitches = 10;
    [System.NonSerialized] public int CurrentNbWitches = 3;

    public List<BaseZone> Zones;
    public HUD _HUD;
    private Fire Fire;
    private void Awake()
    {
        Fire = GetComponent<Fire>();
        Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(StartCoroutine());
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

    private IEnumerator StartCoroutine()
    {
        _HUD.SetAnimalText(AnimalsCount + " / " + AnimalsRequired);
        yield return StartCoroutine(_HUD.Fade(true));
        Fire.Begin();
    }

    public void EndGame(bool victory)
    {
        State = victory ? GameState.WIN : GameState.LOOSE;
        StopAllCoroutines();
        StartCoroutine(EndCoroutine());
    }

    private IEnumerator EndCoroutine()
    {
        yield return _HUD.Fade(false);
        SceneManager.LoadScene("TitleScreen");
    }
}
