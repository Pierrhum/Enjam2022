using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Witch : MonoBehaviour
{
    public int MaxEnergy = 20;
    public GameObject InterrogationSprite;
    public GameObject EnergySprite;
    public Image EnergyFill;
    [System.NonSerialized] public int CurrentEnergy;
    [System.NonSerialized] public bool isDragged = false;
    [System.NonSerialized] public BaseZone CurrentZone;
    private StateMachine StateMachine => GetComponent<StateMachine>();

    private BoxCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        InitializeStateMachine();
    }

    private void Start()
    {
        EnergySprite.SetActive(false);
        CurrentEnergy = MaxEnergy;
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(WaitingState), new WaitingState(witch: this)}, 
            {typeof(FireState), new FireState(witch: this)}, 
            {typeof(AnimalsState), new AnimalsState(witch: this)}, 
            {typeof(SpawnState), new SpawnState(witch: this)}, 
            {typeof(TrainingState), new TrainingState(witch: this)}, 
            {typeof(RestState), new RestState(witch: this)}
        };

        GetComponent<StateMachine>().SetStates(states);
    }
    
    public void OnClick(BaseEventData data)
    {
        // TODO : Something ? 
        Debug.Log("click");
        Debug.Log(transform.gameObject);
    }
    
    public void OnHover(BaseEventData data)
    {
        EnergySprite.SetActive(true);
    }

    public void OnExit(BaseEventData data)
    {
        EnergySprite.SetActive(false);
    }
    public void OnDrag(BaseEventData data)
    {
        isDragged = true;
        //Create a ray going from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
        Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        //Move the GameObject when you drag it
        transform.position = rayPoint;

        InterrogationSprite.SetActive(false);
    }

    public void OnDrop(BaseEventData data)
    {
        isDragged = false;
        // Zone Checking
        if (CurrentEnergy > 0)
        {
            bool FoundZone = false;
            foreach(BaseZone Zone in GameManager.Instance.Zones)
            {
                if (_collider.IsTouching(Zone.Collider))
                {
                    if (Zone.Equals(CurrentZone))
                    {
                        FoundZone = true;
                        break;
                    }
                
                    if (Zone.AddWitch(this))
                    {
                        CurrentZone = Zone;
                        FoundZone = true;
                    }
                }
            }
        
            if(CurrentZone != null && !FoundZone)
            {
                CurrentZone.RemoveWitch(this);
                CurrentZone = null;
            }
        }
        else if (CurrentZone == null)
            InterrogationSprite.SetActive(true);
    }

    public void UpdateEnergy(int delta)
    {
        CurrentEnergy += delta;
        EnergyFill.fillAmount = (float)CurrentEnergy / MaxEnergy;
        
        if (CurrentEnergy <= 0)
            CurrentZone = null;
        
        else if (CurrentEnergy > MaxEnergy) CurrentEnergy = MaxEnergy;
    }

}
