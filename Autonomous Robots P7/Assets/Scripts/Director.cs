using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Serialization;

//TODO: Robotten må ikke køre gennem ting.
//TODO: distance 
//TODO: Grid, et eller andet med sorting. noget med clamp
//TODO: en AI der løber ldit rundt, ??state machine?
//TODO: statisk map.
   
// https://en.wikipedia.org/wiki/Cluster_analysis
// https://towardsdatascience.com/the-5-clustering-algorithms-data-scientists-need-to-know-a36d136ef68
public class Director : MonoBehaviour
{
    public RaycastSensor _raycastSensor;
    public RaycastSensor[] raycastSensors;
    public List<Vector3> points;
    public MapPainter mp;
    public GameObject robot;
    public Matrix matrix;
    
    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.Find("Robot");
        points = new List<Vector3>();
        mp = GetComponent<MapPainter>();

        raycastSensors = robot.GetComponentsInChildren<RaycastSensor>();

        matrix = GetComponent<Matrix>();
    }

    //TODO: Datamodel. 
    // Mathf.Clamp -- https://docs.unity3d.com/ScriptReference/Mathf.Clamp.html
    // Key value pair med clampx og clampz som keys.
    
    
    void AddVector3(Vector3 point)
    {
        //TODO:; Other cools computations Filters
        //JeppeMatrixing af points, så man kan se om man allerede har et givet punkt.
        
        
        
        
        if (!point.Equals(Vector3.zero))
        {
            mp.PlacePointAtOffset(point);
            matrix.AddPointToSquares(point);
            //points.Add(point);
        }
    }

    void FixedUpdate()
    {
        foreach (RaycastSensor rs in  raycastSensors)
        {
            AddVector3(rs.PointOfImpact());
        }
    }
}
