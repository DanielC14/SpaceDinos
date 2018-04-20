using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {

    private float spawnz = -250f;
    public GameObject[] prefabs;
    
    private float RoadLength = 892f;
    private int amountOfRoads = 10;
    private float safeZone = 250f;
    private List<GameObject> roadsList;
    private Transform playerTransform;


	// Use this for initialization
	void Start () {
        roadsList = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i<amountOfRoads; i++)
        SpawnRoad(0);
    }
	
	// Update is called once per frame
	void Update () {

        if(playerTransform.position.z - safeZone > (spawnz - amountOfRoads  * RoadLength))
        {
            SpawnRoad(0);
            DeleteRoad();
        }
		
	}

    void SpawnRoad(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(prefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnz;
        spawnz += RoadLength;
        roadsList.Add(go);
    }

    void DeleteRoad()
    {
        Destroy(roadsList[0]);
        roadsList.RemoveAt(0);
    }
}
