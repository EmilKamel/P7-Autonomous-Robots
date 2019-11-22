using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TODO: lav map.
        //TODO: Instantiate gameobjects i foreach loop i scene.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //TODO: 2d array List<List<field>>
    //
    //Field = pos, points, blocked, frontier. NICE:)
    private List<List<Square>> _matrix;


    private Dictionary<String, Square> _squares;

    // int int --Round--> string x z 
    private string CoordsToString(int x, int y)
    {
        return Mathf.Round(x).ToString() + Mathf.Round(y).ToString();
    }

    //Vector3 --Round--> string x z
    private string Vector3ToString(Vector3 vec)
    {
        return Mathf.Round(vec.x).ToString() + Mathf.Round(vec.z).ToString();
    }
    
    // Checks and adds a point to the _squares Dictionary. If the square exists, adds point to it.
    public void AddPointToSquares(Vector3 point)
    {
        string key = Vector3ToString(point);
        if (_squares.ContainsKey(key))
            return;
        
        Square square = new Square();
        square.AddPoint(point);
        
        _squares.Add(key, square);
    }
    
    // Search for a square in the _squares dictionary. 
    public Square LookUpSquare(int x, int z)
    {
        Square square;
        _squares.TryGetValue(CoordsToString(x, z), out square);
        return square;
    }
    
}
