﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPainter : MonoBehaviour
{
    [SerializeField] private float _height;

    [SerializeField] private GameObject _gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //TODO: 
    
    
    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlacePixelAt(Vector3 pos, Color color)
    {
        GameObject go = Instantiate(_gameObject, pos, Quaternion.identity);
        go.GetComponent<Renderer>().material.color = color;
    }
    
    public void PlacePointAtOffset(Vector3 pos)
    {
        Instantiate(_gameObject, pos + (Vector3.up * _height), Quaternion.identity);

    }
    
}
