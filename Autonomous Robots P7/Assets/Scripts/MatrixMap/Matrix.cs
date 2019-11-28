using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class Matrix : MonoBehaviour
{
    public GameObject paintPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: lav map.
        //TODO: Instantiate GameObjects i foreach loop i scene.
        //TODO: Sæt farve til square.points.count. --> Heatmap :))
        
        _squares = new Dictionary<string, Square>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            PaintMap();
        }
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

    private Vector3 RoundVector3(Vector3 input)
    {
        Vector3 output = new Vector3(Mathf.Round(input.x),Mathf.Round(input.y), Mathf.Round(input.z));
        return output;
    }
    
    // Checks and adds a point to the _squares Dictionary. If the square exists, adds point to it.
    public void AddPointToSquares(Vector3 point)
    {
        string key = Vector3ToString(point);
        if (_squares.ContainsKey(key))
            return;
        
        Square square = new Square();
        square.AddPoint(point);
        square.center = RoundVector3(point);
        
        _squares.Add(key, square);
    }
    
    // Search for a square in the _squares dictionary. 
    public Square LookUpSquare(int x, int z)
    {
        Square square;
        _squares.TryGetValue(CoordsToString(x, z), out square);
        return square;
    }


    public void PaintMap()
    {
        Vector3 offset = Vector3.up * 5;
        Color c;
        foreach (var s in _squares)
        {
            if (s.Value.blocked)
            {
                //Paint blocked mat
                c = Color.red;
            }
            else
            {
                c = Color.white;
            }
            
            GameObject go = Instantiate(paintPrefab,s.Value.center + offset, Quaternion.identity);
            go.GetComponent<Renderer>().material.color = c;
            
            //TODO paint other colors for other values

        }
        
    }
    
}
