using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSensor : MonoBehaviour
{

    public float length;

    private Vector3 posOfRaycast;
    private Vector3 dirOfRaycast;
    
    //TODO: toggle debug printing 

    [SerializeField] private Boolean debugPrint;
    
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        debugPrint = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (debugPrint)
        {
            var poi = PointOfImpact();
            if (poi != Vector3.zero)
            {
                print(poi);
            }
        
            if (Hit())
            {
                Debug.DrawRay(this.transform.position, this.transform.forward * length, Color.red);
                print("Hit");
            }
            else
            {
                Debug.DrawRay(this.transform.position, this.transform.forward *length, Color.blue);
            }
            
        }
       
        
    }

    Boolean Hit()
    {
         return  Physics.Raycast(this.transform.position, this.transform.forward, length);
    }

    //TODO distance på hit.
    
    //TODO: point of impact
    Vector3 PointOfImpact()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
