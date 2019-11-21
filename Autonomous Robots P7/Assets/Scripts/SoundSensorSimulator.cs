using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSensorSimulator : MonoBehaviour
{

    private bool isCurrentlyColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool GetIsCurrentlyColliding(){
        return isCurrentlyColliding;
    }

    void OnTriggerEnter(Collider collider){
        isCurrentlyColliding = true;
    }

    void OnTriggerExit(Collider collider){
        isCurrentlyColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}