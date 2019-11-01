﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RobotMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public bool PlayerControls;

    public bool Forward;
    public bool 
    public bool Left;
    public bool Right;
    public bool Move;


    //TODO Den skal ikke kunne gå gennem kasser osv
    [SerializeField] private RaycastSensor _sensorForward;

    void Update()
    {
        if (PlayerControls)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(3 * Time.deltaTime * this.transform.forward, Space.World);
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(200 * Time.deltaTime * -transform.up, Space.World);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Rotate(200 * Time.deltaTime * transform.up, Space.World);
            }
        }
        else
        {
            
            if (Forward)
            {
                this.transform.Translate(3 * Time.deltaTime * this.transform.forward, Space.World);
            }
            else
            {
                this.transform.Translate(3 * Time.deltaTime * this.transform.forward, Space.World);
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(200 * Time.deltaTime * -transform.up, Space.World);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Rotate(200 * Time.deltaTime * transform.up, Space.World);
            }
        }
    }


    //TODO interface til movement.
}