using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class RaycastSensor : MonoBehaviour
{

    public float hitLength;
    public float poiLength;

    public enum ImpactType
    {
        Point, GameObject, ForwardOffset
    }

    [SerializeField] public ImpactType _impactType;
    
    private Vector3 posOfRaycast;
    private Vector3 dirOfRaycast;
    
    //TODO: toggle debug printing 

    [SerializeField] private Boolean debugPrint;
    
    public Color color;
    // Start is called before the first frame update
    void Start()
    {

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
                Debug.DrawRay(this.transform.position, this.transform.forward * hitLength, Color.red);
                print("Hit");
            }
            else
            {
                Debug.DrawRay(this.transform.position, this.transform.forward *hitLength, Color.blue);
            }
            
        }
        
    }

    public Boolean Hit()
    {
         return  Physics.Raycast(this.transform.position, this.transform.forward, hitLength);
    }
    
    //TODO maxdistance?
    public float Distance()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            return hit.distance;
        }
        else return float.MaxValue;
    }
    
    //TODO: point of impact
    public Vector3 PointOfImpact()
    {
        switch (_impactType)
        {
            case ImpactType.Point:
                PointOfImpactSimple();
                break;
            case ImpactType.GameObject:
                return PointOfImpactObject();
            case ImpactType.ForwardOffset:
                return PointOfImpactWithForward();
        }

        return Vector3.zero;
    }

    public Vector3 PointOfImpactSimple()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, poiLength))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
    
    public Vector3 PointOfImpactWithForward()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, poiLength))
        {
            return hit.point + (this.transform.forward * 0.1f);
        }
        return Vector3.zero;
    }

    public Vector3 PointOfImpactObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, poiLength))
        {
            return hit.collider.transform.position;
        }
        return Vector3.zero;
    }
    
}
