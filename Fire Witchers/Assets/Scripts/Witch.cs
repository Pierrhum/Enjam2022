using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Witch : MonoBehaviour
{
    public GameObject InterrogationSprite;
    [System.NonSerialized] public BaseZone CurrentZone;
    private StateMachine StateMachine => GetComponent<StateMachine>();

    private BoxCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        InitializeStateMachine();
    }
    
    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(WaitingState), new WaitingState(witch: this)}, 
            {typeof(FireState), new FireState(witch: this)}
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
        // TODO : Start Glowing effect 
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void OnExit(BaseEventData data)
    {
        // TODO : Stop Glowing effect 
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void OnDrag(BaseEventData data)
    {
        //Create a ray going from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
        Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        //Move the GameObject when you drag it
        transform.position = rayPoint;

        if (StateMachine.CurrentState is WaitingState)
        {
            InterrogationSprite.SetActive(false);
        }
    }

    public void OnDrop(BaseEventData data)
    {
        if (StateMachine.CurrentState is WaitingState)
        {
            InterrogationSprite.SetActive(true);
        }

        // Zone Checking
        if (_collider.IsTouching(GameManager.Instance.FireZone.Collider))
        {
            if(GameManager.Instance.FireZone.AddWitch(this)) CurrentZone = GameManager.Instance.FireZone;
            else Debug.Log("can't add in Fire zone");
        } 
        else
        {
            if (CurrentZone != null)
            {
                CurrentZone.RemoveWitch(this);
                CurrentZone = null;
            }
        }; 
    }

}
