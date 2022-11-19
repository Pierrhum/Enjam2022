using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Witch : MonoBehaviour
{
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
    }

    public void OnDrop(BaseEventData data)
    {
        Debug.Log("drop");
        // TODO : Zone Checking 
    }

}
