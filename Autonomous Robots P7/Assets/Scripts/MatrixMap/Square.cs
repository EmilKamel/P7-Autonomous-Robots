﻿using System;
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
    public bool _blocked;
    public Status _status;
    public GameObject SquareGameObject;

    public enum Direction
    {
        Forward, Behind, Left, Right
    }
    

    public enum Status
    {
        Blocked, Frontier, Explored
    }

    public Status GetStatus()
    {
        return _status;
    }

    public void TestFrontier()
    {
        
        //No 
    }
    
    //TODO,, relations til naboer

    public Vector3 GetNeighbour(Direction dir)
    {
        Vector3 output = Vector3.zero;

        switch (dir)
        {
            case Direction.Forward:
                output = center + Vector3.forward;
                break;
            case Direction.Behind:
                output = center + Vector3.back;
                break;
            case Direction.Left:
                output = center + Vector3.left;
                break; 
            case Direction.Right:
                output = center + Vector3.right;
                break;
        }
        return output;
    }
    
    public void AddPoint(Vector3 point, Status state)
    {
        if (_blocked == null || _blocked == false)
        {
            if (_points == null)
            {
                _points = new List<Vector3>();
            }

            
            switch (state)
            {
                case Status.Blocked:
                    _blocked = true;
                    _status = Status.Blocked;
                    break;
                case Status.Explored:
                    _status = Status.Explored;
                    _blocked = false;
                    break;
                case Status.Frontier:
                    if (_status == Status.Blocked || _status == Status.Explored)
                        break;
                    _status = Status.Frontier;
                    break;
            }
            
            _points.Add(point);
        }
    }
}
