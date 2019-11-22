using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeppeBestMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

public class Vertex : MonoBehaviour
{
    //TODO This.pos som 00 vertex
    //TODO 00 vertex's naboer tilføjes og gøres til frontier
    //TODO Hvis hit(), så er denne vertex blocked.


    public Vector3 pos;
   // public Bool frontier;
    //public Bool blocked;

    public List<Vertex> Neighbors;
}



