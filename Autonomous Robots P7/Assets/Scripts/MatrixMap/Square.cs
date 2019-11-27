using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 center;
    List<Vector3> _points;
    public bool blocked;

    public void AddPoint(Vector3 point)
    {
        if (blocked == null || blocked == false)
        {
            if (_points == null)
            {
                _points = new List<Vector3>();
            }
            
            blocked = true; 
            _points.Add(point);
        }
    }
}
