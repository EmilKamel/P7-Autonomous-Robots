using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAIV1 : MonoBehaviour
{
    public bool Active;

    [SerializeField] private RobotMover _robot;
    [SerializeField] private RaycastSensor _sensorForward;

    [SerializeField] public SoundSensorSimulator soundSensorSimulator;

    private bool isNotCurrentlyBacking = true;
    private float backingTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _robot = transform.GetComponent<RobotMover>();
        _sensorForward = _robot._sensorForward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            if(!soundSensorSimulator.GetIsCurrentlyColliding() && isNotCurrentlyBacking){
                if (_sensorForward.Hit())
                {
                    _robot.SetMovements(false, false, true, false);
                }
                else
                {
                    _robot.SetMovements(true, false, false, false);
                }
            }
            else{
                _robot.SetMovements(false, true, true, false);
                backingTimer -= Time.deltaTime;
                isNotCurrentlyBacking = false;
                if(backingTimer < 0){
                    backingTimer = 0.5f;
                    isNotCurrentlyBacking = true;
                }
            }
            //TODO: statemachine.
        }
    }
}