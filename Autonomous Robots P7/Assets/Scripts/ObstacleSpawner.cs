using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    //TODO https://thoughtbot.com/blog/how-to-git-with-unity
    public GameObject Prefab;
    
    public float rangeX;
    
    public float rangeY;

    public float rangeZ;
    
    public int amountToGenerate;

    // current gameobjects
    public List<GameObject> currentGos;
    
    // Start is called before the first frame update
    void Start()
    {
        GeneratePrefabs();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            RemoveAllPrefabs();
        }

        if (Input.GetKey(KeyCode.J))
        {
            GeneratePrefabs();
        }
    }

    //TODO tilfældige former og rotationer
    private void GeneratePrefabs()
    {
        for (int i = 0; i < amountToGenerate; i++)
        {
            Vector3 pos = this.transform.position;
            GeneratePrefab(
                pos.x + Random.Range(-rangeX, rangeX),
                pos.y + Random.Range(-rangeY, rangeY),
                pos.z + Random.Range(-rangeZ, rangeZ));
        }
    }

    private void GeneratePrefab(float x, float y, float z)
    {
        currentGos.Add(Instantiate(Prefab, new Vector3(x, y, z), Quaternion.identity));
    }

    private void RemoveAllPrefabs()
    {
        if(currentGos.Count >= 1)
            foreach (var go in currentGos)
            {
                Destroy(go);
                currentGos.Remove(go);
            }
        
    }
    
}