using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RobotMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // true if a boii controls robot.
    public bool PlayerControls;

    //Directions
    [SerializeField] private bool _Forward;
    [SerializeField] private bool _Back;
    [SerializeField] private bool _Left;
    [SerializeField] private bool _Right;
    [SerializeField] private bool _Move;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    //TODO Den skal ikke kunne gå gennem kasser osv
    [SerializeField] private RaycastSensor _sensorForward;

    void Update()
    {
        if (PlayerControls)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(_moveSpeed * Time.deltaTime * this.transform.forward, Space.World);
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(_moveSpeed * Time.deltaTime * -this.transform.forward, Space.World);
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(_rotationSpeed * Time.deltaTime * -transform.up, Space.World);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Rotate(_rotationSpeed * Time.deltaTime * transform.up, Space.World);
            }
        }
        else
        {
            if (_Forward)
            {
                this.transform.Translate(_moveSpeed * Time.deltaTime * this.transform.forward, Space.World);
            }

            if (_Back)
            {
                this.transform.Translate(_moveSpeed * Time.deltaTime * -this.transform.forward, Space.World);
            }

            if (_Left)
            {
                this.transform.Rotate(_rotationSpeed * Time.deltaTime * -transform.up, Space.World);
            }

            if (_Right)
            {
                this.transform.Rotate(_rotationSpeed * Time.deltaTime * transform.up, Space.World);
            }
        }
    }

    public void SetMovements(bool forward, bool back, bool right, bool left)
    {
        _Forward = forward;
        _Back = back;
        _Right = right;
        _Left = left;
    }


    //TODO interface til movement.
}