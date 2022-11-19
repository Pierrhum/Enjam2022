using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Boundary = 20;
    public float Speed = 5f;
    private Camera Camera;

    private void Awake()
    {
        Camera = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (Input.mousePosition.x > Screen.width - Boundary)
        {
            transform.position += new Vector3(Speed * Time.deltaTime,0,0);
        } else if (Input.mousePosition.x < 0 + Boundary)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime,0,0);
        }
    }
}
