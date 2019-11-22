using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    List<Vector3> _points;
    private bool blocked;

    public void AddPoint(Vector3 point)
    {
        if (blocked == null || blocked == false)
        {
            blocked = true; 
            _points.Add(point);
        }
    }
}
