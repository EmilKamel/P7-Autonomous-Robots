using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        if (Input.GetKeyDown(KeyCode.N))
        {
            AddNeighbours();
            
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
    public void AddPointToSquares(Vector3 point, Boolean blocked)
    {
        string key = Vector3ToString(point);
        if (_squares.ContainsKey(key))
            return;
        
        Square square = new Square();
        square.AddPoint(point, Square.Status.Blocked);
        square.center = RoundVector3(point);
        
        _squares.Add(key, square);
    }

    public void AddPointToSquares(Vector3 point, Square.Status state)
    {
        string key = Vector3ToString(point);
        if (_squares.ContainsKey(key))
            return;
        
        Square square = new Square();
        square._status = state;
        square.AddPoint(point, state);
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

    public Square LookUpSquareVector3(Vector3 vec)
    {
        vec = RoundVector3(vec);
        return LookUpSquare((int)vec.x, (int)vec.z);
    }


    public Square NeighbourSquare(Square square ,Square.Direction direction)
    {
        return LookUpSquareVector3(square.GetNeighbour(direction));
    }
    
    public void AddNeighbours()
    {
        Dictionary<string, Square> dic = _squares.Where(s => s.Value.GetStatus() == Square.Status.Explored).ToDictionary(s => s.Key, s => s.Value);


        List<Vector3> output = new List<Vector3>();
        foreach (var s in dic)
        { 
            Vector3 pos = s.Value.center;

                
                Square neighbour;
                //FREM
                if(_squares.TryGetValue(Vector3ToString(pos + Vector3.forward), out neighbour))
                {    
                    //square exists    
                }
                else
                {
                    output.Add(pos + Vector3.forward);
                }
                //TILBAGE
                if(_squares.TryGetValue(Vector3ToString(pos + -Vector3.forward), out neighbour))
                {    
                    //square exists    
                }
                else
                {
                    output.Add(pos + -Vector3.forward);
                }
                //FRA SIDE
                if(_squares.TryGetValue(Vector3ToString(pos + Vector3.left), out neighbour))
                {    
                    //square exists    
                }
                else
                {
                    output.Add(pos + Vector3.left);
                }
                // TIL SIDE
                if(_squares.TryGetValue(Vector3ToString(pos + Vector3.right), out neighbour))
                {    
                    //square exists    
                }
                else
                {
                    output.Add(pos + Vector3.right);
                }
        }
        foreach (var o in output)
        {
            AddPointToSquares(o, Square.Status.Frontier);
        }
    }
    

    public void PaintMap()
    {
        Vector3 offset = Vector3.up * 5;
        Color c = Color.white;
        foreach (var s in _squares)
        {
            switch (s.Value.GetStatus())
            {
                case Square.Status.Blocked:
                    //Paint blocked mat
                    c = Color.red;
                    break;
                case Square.Status.Explored:
                    c = Color.green;
                    break;
                case Square.Status.Frontier:
                    c = Color.blue;
                    break;
            }
            
            GameObject go = Instantiate(paintPrefab,s.Value.center + offset, Quaternion.identity);
            go.GetComponent<Renderer>().material.color = c;
            
            //TODO paint other colors for other values

        }
        
    }
    
}
