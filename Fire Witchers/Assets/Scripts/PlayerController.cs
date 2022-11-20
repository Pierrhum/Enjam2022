using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int Boundary = 20;
    public float Speed = 5f;
    public SpriteRenderer Map;
    private Camera Camera;

    private void Awake()
    {
        Camera = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Mathf.Clamp(transform.position.x + Speed * Time.deltaTime, Map.transform.position.x - Map.bounds.size.x/2, Map.transform.position.x + Map.bounds.size.x/2), 0, 0);
        if (Input.mousePosition.x > Screen.width - Boundary)
        {
            transform.position += new Vector3(Speed * Time.deltaTime,0,0);
        } else if (Input.mousePosition.x < 0 + Boundary)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime,0,0);
        }
        
    }
}
